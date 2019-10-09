using BaseLib.Models;
using UserMgt.Models;
using UserMgt.Utils;
using FNMusic.Models;
using FNMusic.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserMgt.Services;
using BaseLib.Utils;
using FNMusic.Services;

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
            IHttpContextAccessor httpContextAccessor
            )
        {    
            this.authService = authService;
            this.userService = userService;
            this.systemService = systemService;
            this.httpContextAccessor = httpContextAccessor;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        [Route("/register")]
        public IActionResult Register()
        {
            HttpContext.Session.Clear();
            List<SelectListItem> GenderList = new List<SelectListItem>() {
                new SelectListItem(){ Text = "Select Gender", Value = null, Selected = true },
                new SelectListItem(){ Text = "Male", Value = "M" },
                new SelectListItem(){ Text = "Female", Value = "F" },
                new SelectListItem(){ Text = "Unspecified", Value = "U", Disabled = true }
            };

            return View();
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kindly fill in the necessary details");              
                return View(model);
            }

            return await Task.Run(async () =>
            {
                try
                {
                    string json = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResult<ServiceResponse> result = await authService.RegisterAsync(content);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }

                    await SendConfirmationMail(model.Email);
                    if (result.Content != null)
                    {
                        Login login = new Login
                        {
                            UserId = model.Email,
                            Password = model.Password
                        };

                        return await Login(login, "/" + model.Username + "/updateprofile");
                    }

                    return Redirect("/login");
                }
                catch (Exception ex)
                {
                    return View(model).WithDanger("Something went wrong", ex.Message);
                }
            });     
        }

        [Route("/login")]
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
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
        public async Task<IActionResult> Login(Login model, [FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kindly fill in the necessary details");
                return View(model);
            }

            return await Task.Run(async () => 
            {
                try
                {
                    HttpResult<AccessTokenWithUserDetails> result = await authService.LogInAsync(model.UserId, model.Password);
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
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    systemService.SetHttpContext(user, feature, accessToken, "");
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        if (Convert.ToBoolean(HttpContext.User.Claims.First(x => x.Type == "TwoFactorEnabled").Value) == true)
                        {
                            await SendLoginVerificationToken();
                            session.SetString("TFE", true.ToString());
                            return Redirect("/login/verification");
                        }
                    }

                    if (returnUrl != null && returnUrl != "")
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

                    return View(model).WithDanger("Login Failed!", ex.Message);
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
        public IActionResult ForgotPassword()
        {
            session.Remove("PRP");
            session.Remove("PRPV");
            session.Remove("Sent");
            return View();
        }

        [HttpPost]
        [Route("/forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "kindly fill in necessary details");
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
                        HttpResult<Result<User>> httpUserResult = await userService.FindUserByEmail(forgotPassword.Email, null);
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
        public IActionResult ResetPassword([FromRoute(Name = "Token")] string token)
        {
            ResetPassword resetPassword = new ResetPassword()
            {
                Token = token
            };

            session.Remove("EMAILEXISTS");
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
                    bool emailExists = Convert.ToBoolean(session.GetString("EMAILEXISTS"));
                    bool reset = Convert.ToBoolean(session.GetString("RESET"));

                    if (!emailExists)
                    {
                        HttpResult<Result<User>> httpResult = await userService.FindUserByEmail(resetPassword.Email, null);
                        if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status) || httpResult.Content.Data.Email != resetPassword.Email)
                        {
                            ServiceResponse response = httpResult.FailureResponse;
                            throw new Exception(response.Description);
                        }

                        session.SetString("EMAILEXISTS", true.ToString());
                    }

                    if (emailExists && !reset)
                    {
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