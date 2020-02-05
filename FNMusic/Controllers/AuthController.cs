using BaseLib.Models;
using FNMusic.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FNMusic.Services;
using BaseLib.Utils;
using System.Text.RegularExpressions;
using UserMgt.Models;
using UserMgt.Services;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FNMusic.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService<ServiceResponse> authService;
        private IUserService<Result<User>> userService;
        private SystemService systemService;
        private IHttpContextAccessor httpContextAccessor;
        private ISession session;

        public AuthController(
            IAuthService<ServiceResponse> authService, 
            IUserService<Result<User>> userService,
            SystemService systemService,
            IHttpContextAccessor httpContextAccessor)
        {    
            this.authService = authService;
            this.userService = userService;
            this.systemService = systemService;
            this.httpContextAccessor = httpContextAccessor;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        [Route("/register")]
        public IActionResult Register([FromQuery(Name = "authkey")] AuthKey authKey)
        {
            HttpContext.Session.Clear();
            Register register = new Register
            {
                AuthKey = authKey
            };

            return View(register);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(Register register)
        {
            register.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kindly fill in the necessary details");              
                return View(register);
            }

            try
            {
                await Task.Run(async () =>
                {
                    string json = JsonConvert.SerializeObject(register);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResult<ServiceResponse> result = await authService.RegisterAsync(content);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }
                });

                await SendConfirmationMail(register.Email);
                Login login = new Login
                {
                    Password = register.Password,
                    AuthKey = register.AuthKey
                };

                switch (register.AuthKey)
                {
                    case AuthKey.Email:
                        login.UserId = register.Email;
                        break;

                    case AuthKey.Phone:
                        login.UserId = register.Phone;
                        break;
                }

                await Login(login,null);
                return Redirect("/login?ReturnUrl=/"+register.Username+"/updateProfile");
            }
            catch (Exception ex)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    await HttpContext.SignOutAsync();
                    return Redirect("/login");
                }

                return View(register).WithDanger("Oops", ex.Message);
            }
        }

        
        [Route("/login")]
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return Redirect("/discover");
            }

            ViewData["Title"] = "Login";
            if (returnUrl != null || returnUrl != "")
            {
                ViewData["ReturnUrl"] = returnUrl;
            }

            return View();
        }
        
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(Login login, [FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kindly fill in the necessary details");
                return View(login);
            }

            var emailRegex = "^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$";
            var matchesEmail = Regex.Match(login.UserId, emailRegex);
            bool matchesPhone = long.TryParse(login.UserId, out long n);

            if (matchesEmail.Success)
                login.AuthKey = AuthKey.Email;
            else if (matchesPhone)
                login.AuthKey = AuthKey.Phone;
            else
                login.AuthKey = AuthKey.Username;

            return await Task.Run(async () => 
            {
                try
                {
                    HttpResult<AccessTokenWithUserDetails> result = await authService.LogInAsync(login);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }

                    AccessTokenWithUserDetails accessTokenWithUserDetails = result.Content;
                    if (accessTokenWithUserDetails == null)
                    {
                        throw new Exception();
                    }

                    User user = accessTokenWithUserDetails.User;
                    Feature feature = accessTokenWithUserDetails.Feature;
                    string accessToken = accessTokenWithUserDetails.AccessToken;
                    string refreshToken = accessTokenWithUserDetails.RefreshToken ?? "";
                    await systemService.SetHttpContext(user, feature, accessToken, refreshToken);
                    if (user.TwoFactorEnabled)
                    {
                        await SendLoginVerificationToken();
                        session.SetString("TFE", true.ToString());
                        return Redirect("/login/verification");
                    }

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return Redirect("/discover");
                }
                catch (Exception ex)
                {
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        await HttpContext.SignOutAsync();
                    }

                    return View(login).WithDanger("Login Failed!", ex.Message);
                }
            });        
        }

        [Authorize]
        [HttpPost]
        [Route("/sendloginverificationtoken")]
        public async Task<ActionResult> SendLoginVerificationToken()
        {
            try
            {
                string email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;
                HttpResult<ServiceResponse> result = await authService.LoginVerificationAsync(email);
                if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                {
                    var response = result.FailureResponse;
                    throw new Exception(response.Description);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("/login/verification")]
        public IActionResult LoginVerification()
        {   
            string email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;
            TwoFactorVerification model = new TwoFactorVerification()
            {
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        [Route("/login/verification")]
        public async Task<IActionResult> LoginVerification(TwoFactorVerification model)
        {
            model.Email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<ServiceResponse> result = await authService.LoginTokenVerificationAsync(model.Email, model.Token);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }

                    session.SetString("TFV", true.ToString());
                    return Redirect("/discover");
                }
                catch (Exception ex)
                {
                    return View(model).WithDanger("Something went wrong", ex.Message);
                }
            });
        }

        [Route("/confirm/{email}")]
        public async Task<IActionResult> SendConfirmationMail([FromRoute(Name = "email")] string email)
        {
            try
            {
                HttpResult<ServiceResponse> result = await authService.SendEmailConfirmationMessageAsync(email);
                if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                {
                    ServiceResponse response = result.FailureResponse;
                    throw new Exception(response.Description);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/activate/{Token}")]
        public IActionResult Activate([FromRoute(Name = "Token")] string token) 
        {
            Activate activate = new Activate
            {
                Token = token
            };

            session.Remove("Activated");
            return View(activate);
        }

        [HttpPost]
        [Route("/activate/{Token}")]
        public async Task<IActionResult> Activate(Activate activate, [FromRoute(Name = "Token")] string token)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(activate.Email))
                {
                    ModelState.AddModelError("", "Kindly input your email");
                }

                if (string.IsNullOrEmpty(activate.Token))
                {
                    Response.Redirect("/");
                }

                return View(activate);
            }

            return await Task.Run(async () => 
            {
                try
                {
                    HttpResult<ServiceResponse> result = await authService.ActivateAccountAsync(activate.Email, activate.Token);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }

                    session.SetString("Activated", true.ToString());
                    if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                    {
                        await httpContextAccessor.HttpContext.SignOutAsync();
                    }

                    return View();
                }
                catch (Exception ex)
                {
                    return View(activate).WithDanger("Oops",ex.Message);
                }
            });
        }

        [Route("/sendforgotpasswordverificationtoken")]
        public async Task<IActionResult> SendForgotPasswordVerificationToken([FromRoute(Name = "email")] string email)
        {
            try
            {
                HttpResult<ServiceResponse> result = await authService.ForgotPasswordVerificationAsync(email);
                if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                {
                    ServiceResponse response = result.FailureResponse;
                    throw new Exception(response.Description);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/forgotpassword")]
        public IActionResult ForgotPassword([FromQuery(Name = "fpa")] AuthKey authKey)
        {
            session.Remove("PRP");
            session.Remove("PRPV");
            session.Remove("Sent");

            ForgotPassword forgotPassword = new ForgotPassword
            {
                AuthKey = authKey
            };

            return View(forgotPassword);
        }

        [HttpPost]
        [Route("/forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword, [FromQuery(Name = "fpa")] AuthKey authKey )
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "*");
                return View(forgotPassword);
            }

            return await Task.Run(async () =>
            {
                try
                {
                    bool PRP = Convert.ToBoolean(session.GetString("PRP"));
                    bool PRPV = Convert.ToBoolean(session.GetString("PPRV"));

                    if (!PRP)
                    {
                        HttpResult<Result<User>> httpUserResult = null;
                        if (forgotPassword.AuthKey == AuthKey.Email)
                        {
                            httpUserResult = await userService.FindUserByEmail(forgotPassword.Email, null);
                            
                        }
                        else if (forgotPassword.AuthKey == AuthKey.Phone)
                        {
                            httpUserResult = await userService.FindUserByPhone(forgotPassword.Phone, null);
                        }

                        if (!HttpStatusUtils.Is2xxSuccessful(httpUserResult.Status) || httpUserResult.Content == null || httpUserResult.Content.Data.Email != forgotPassword.Email)
                        {
                            ServiceResponse response = httpUserResult.FailureResponse;
                            throw new Exception(response.Description);
                        }
                        Result<User> result = httpUserResult.Content;
                        User user = result.Data;
                        if (user.PasswordResetProtection)
                        {
                            await SendForgotPasswordVerificationToken(forgotPassword.Email);
                            session.SetString("PRP", true.ToString());
                        }
                    }
                    
                    if (PRP && !PRPV)
                    {
                        HttpResult<ServiceResponse> httpAuthResult = await authService.ForgotPasswordTokenVerificationAsync(forgotPassword.Email, forgotPassword.Token);
                        if (!HttpStatusUtils.Is2xxSuccessful(httpAuthResult.Status))
                        {
                            ServiceResponse response = httpAuthResult.FailureResponse;
                            throw new Exception(response.Description);
                        }

                        session.SetString("PPRV", true.ToString());
                    }

                    if (PRP & PRPV || !PRP && !PRPV)
                    {
                        HttpResult<ServiceResponse> httpResult = await authService.PasswordResetAsync(forgotPassword.Email, "/resetpassword/");
                        if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                        {
                            ServiceResponse response = httpResult.FailureResponse;
                            throw new Exception(response.Description);
                        }

                        session.SetString("Sent", true.ToString());
                    }
                    
                    return View(forgotPassword);
                }
                catch (Exception ex)
                {
                    return View(forgotPassword).WithDanger("Oops", ex.Message);
                }
            });
        }

        [Route("/resetpassword/{Token}")]
        public IActionResult ResetPassword([FromRoute(Name = "Token")] string token, [FromQuery(Name = "rpa")] AuthKey authKey)
        {
            ResetPassword resetPassword = new ResetPassword()
            {
                Token = token,
                AuthKey = authKey
            };

            session.Remove("EXISTS");
            session.Remove("RESET");
            return View(resetPassword);
        }

        [HttpPost]
        [Route("/resetpassword/{Token}")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    bool Exists = Convert.ToBoolean(session.GetString("EXISTS"));
                    bool reset = Convert.ToBoolean(session.GetString("RESET"));

                    if (!Exists)
                    {
                        HttpResult<Result<User>> httpResult = null;
                        if (resetPassword.AuthKey == AuthKey.Email)
                            httpResult = await userService.FindUserByEmail(resetPassword.Email, null);
                        else if (resetPassword.AuthKey == AuthKey.Phone)
                            httpResult = await userService.FindUserByPhone(resetPassword.Phone, null);

                        if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status) || httpResult.Content.Data.Email != resetPassword.Email)
                        {
                            ServiceResponse response = httpResult.FailureResponse;
                            throw new Exception(response.Description);
                        }

                        session.SetString("EXISTS", true.ToString());
                    }

                    if (Exists && !reset)
                    {
                        if (!ModelState.IsValid)
                        {
                            ModelState.AddModelError("", "*");
                        }

                        HttpResult<ServiceResponse> result = await authService.ResetPasswordAsync(resetPassword.Email, resetPassword.Password, resetPassword.Token);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            ServiceResponse response = result.FailureResponse;
                            throw new Exception(response.Description);
                        }

                        session.SetString("RESET", true.ToString());
                    }

                    return View(resetPassword);
                }
                catch (Exception ex)
                {
                    return View(resetPassword).WithDanger("Oops", ex.Message);
                } 
            });
        }
 
    }
}