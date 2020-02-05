using System;
using System.Linq;
using System.Threading.Tasks;
using BaseLib.Models;
using BaseLib.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FNMusic.Models;
using FNMusic.Services;
using FNMusic.Utils;
using UserMgt.Models;
using UserMgt.Services;
using System.Security.Claims;

namespace FNMusic.Controllers
{
    [Authorize]
    [Route("/settings")]
    public class SettingsController : Controller
    {

        private readonly IUserService<Result<User>> userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAccountSettingsService<ServiceResponse> accountSettingsService;
        private SystemService systemService;
        private readonly string accessToken;

        public SettingsController(
            IUserService<Result<User>> userService, 
            IHttpContextAccessor httpContextAccessor, 
            IAccountSettingsService<ServiceResponse> accountSettingsService,
            SystemService systemService)
        {
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
            this.accountSettingsService = accountSettingsService;
            this.systemService = systemService;
            accessToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-TOKEN").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account")]
        public IActionResult AccountSettings()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/username")]
        public IActionResult UpdateUsername()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("account/username")]
        public async Task<IActionResult> UpdateUsername(UpdateUsername updateUsername)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    string username = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value;
                    if (updateUsername.Username == username)
                    {
                        throw new Exception("You need to change your username");
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdateUsernameAsync(updateUsername.Username, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await systemService.UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View(updateUsername).WithDanger("Oops",e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/phone")]
        public IActionResult UpdatePhone()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
            Update update = new Update
            {
                Phone = principal.Claims.First(x => x.Type == "Phone").Value
            };

            bool phoneExists = !string.IsNullOrEmpty(principal.Claims.First(x => x.Type == "Phone").Value);
            bool phoneConfirmed = Convert.ToBoolean(principal.Claims.First(x => x.Type == "PhoneConfirmed").Value);

            if (phoneExists && !phoneConfirmed)
            {
                httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
            }

            return View(update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("account/phone")]
        public async Task<IActionResult> UpdatePhone(Update update)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    bool VerificationCodeSent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("VCSent"));
                    if (!VerificationCodeSent)
                    {
                        HttpResult<ServiceResponse> result = await accountSettingsService.UpdatePhoneAsync(update.Phone, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
                        await systemService.UpdateHttpContext();
                        return View(update);
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdatePhoneVerificationAsync(update.Phone, update.Token, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await systemService.UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View(update).WithDanger("Oops", e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("account/phone/token/{Phone}")]
        public async Task<IActionResult> SendUpdatePhoneVerificationToken([FromRoute(Name = "Phone")] string phone)
        {
            try
            {
                ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
                if (!phone.Equals(principal.Claims.First(x => x.Type == "Phone").Value))
                {
                    throw new Exception("Invalid Request");
                }
                await accountSettingsService.SendPhoneVerificationTokenAsync(phone, accessToken);
                return Ok("A verification token has been sent to "+phone+"");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/email")]
        public async Task<IActionResult> UpdateEmail()
        {
            return await Task.Run(() =>
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
                    Update update = new Update
                    {
                        Email = principal.Claims.First(x => x.Type == "Email").Value
                    };
                    bool emailExists = !string.IsNullOrEmpty(principal.Claims.First(x => x.Type == "Email").Value);
                    bool emailConfirmed = Convert.ToBoolean(principal.Claims.First(x => x.Type == "EmailConfirmed").Value);
                    if (emailExists && !emailConfirmed)
                    {
                        httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
                    }

                    return View(update);
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("account/email")]
        public async Task<IActionResult> UpdateEmail(Update update)
        {
            return await Task.Run(async() =>
            {
                try
                {
                    bool verificationTokenSent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("VCSent"));
                    if (!verificationTokenSent)
                    {
                        
                        HttpResult<ServiceResponse> result = await accountSettingsService.UpdateEmailAsync(update.Email, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
                        await systemService.UpdateHttpContext();
                        return View(update);
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdateEmailVerificationAsync(update.Email, update.Token, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await systemService.UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("account/email/token/{Email}")]
        public async Task<IActionResult> SendUpdateEmailVerificationToken([FromRoute(Name = "Email")] string email)
        {
            try
            {
                ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
                if (!email.Equals(principal.Claims.First(x => x.Type == "Email").Value))
                {
                    throw new Exception("Invalid Request");
                }
                await accountSettingsService.SendEmailVerificationTokenAsync(email, accessToken);
                return Ok("A verification token has been sent to " + email + "");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/password")]
        public async Task<IActionResult> UpdatePassword()
        {
            return await Task.Run(() =>
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View();
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatePassword"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("account/password")]
        public async Task<IActionResult> UpdatePassword(UpdatePassword updatePassword)
        {
            if (!ModelState.IsValid)
            {
                return View(updatePassword);
            }

            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdatePasswordAsync(updatePassword.CurrentPassword, updatePassword.NewPassword, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View(updatePassword).WithDanger("Oops", e.Message);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/security")]
        public IActionResult Security()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("account/security/twofactor")]
        public IActionResult UpdateTwofactor()
        {
            bool isTwoFactorEnabled = Convert.ToBoolean(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "TwoFactorEnabled").Value);
            httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }


        [Authorize]
        [Route("account/security/twofactor/phone")]
        public IActionResult UpdateTwoFactorByPhone()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [Authorize]
        [HttpPost("account/security/twofactor/phone")]
        public async Task<IActionResult> UpdateTwoFactorByPhone(UpdateTwoFactorByPhone updateTwoFactorByPhone)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return await Task.Run(async () => 
            {
                try
                {
                    
                    string phone = httpContextAccessor.HttpContext.User.Claims.First(X => X.Type == "Phone").Value;
                    bool status = Convert.ToBoolean(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "TwoFactorEnabled").Value) ? false : true;
                    bool passwordVerified = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("PV"));
                    if (!passwordVerified)
                    {
                        if (string.IsNullOrEmpty(updateTwoFactorByPhone.Password))
                        {
                            return View(updateTwoFactorByPhone).WithWarning("Oops", "you did not insert your password");
                        }
                        var httpResult = await accountSettingsService.VerifyPasswordAsync(updateTwoFactorByPhone.Password, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                        {
                            throw new Exception(httpResult.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("PV", true.ToString());
                        await SendTwoFactorVerificationToken(phone);
                        return View(updateTwoFactorByPhone).WithSuccess("Good","A verification code has been sent to your phone");
                    }

                    
                    if (passwordVerified)
                    {
                        if (string.IsNullOrEmpty(updateTwoFactorByPhone.Token))
                        {
                            return View(updateTwoFactorByPhone).WithWarning("Oops", "you did not insert your verification code");
                        }
                        var httpResult = await accountSettingsService.UpdateTwoFactorAsync(phone, status, updateTwoFactorByPhone.Token, accessToken);
                        await systemService.UpdateHttpContext();
                        return Redirect("/settings/account/security/twofactor");
                    }

                    return View(updateTwoFactorByPhone);
                }
                catch (Exception e)
                {
                    return View(updateTwoFactorByPhone).WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [HttpPost("account/security/twofactor/phone/token/{Phone}")]
        public async Task<IActionResult> SendTwoFactorVerificationToken([FromRoute(Name="Phone")] string phone)
        {
            try
            {
                var httpResult = await accountSettingsService.SendTwoFactorVerificationTokenAsync(phone, accessToken);
                if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                {
                    throw new Exception(httpResult.FailureResponse.Description);
                }
                return Ok("A verification code has been sent to your mobile number");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [Route("account/security/password/reset/protection")]
        public IActionResult UpdatePasswordResetProtection()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [Authorize]
        [HttpPost("account/security/password/reset/protection")]
        public async Task<IActionResult> UpdatePasswordResetProtection(UpdatePasswordResetProtection updatePasswordResetProtection)
        {
            if (!ModelState.IsValid)
            {
                return View(updatePasswordResetProtection);
            }

            return await Task.Run(async () =>
            {
                try
                {
                    bool status = Convert.ToBoolean(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "PasswordResetProtection").Value) ? false : true;
                    var httpResult = await accountSettingsService.UpdatePasswordResetProtectionAsync(status, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await systemService.UpdateHttpContext();
                    return Redirect("/settings/account/security");
                }
                catch (Exception e)
                {
                    return View(updatePasswordResetProtection).WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [Route("account/country")]
        public Task<IActionResult> UpdateCountry()
        {
            return Task.Run(()=> 
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View();
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [Route("account/deactivate")]
        public Task<IActionResult> DeactivateAccount()
        {
            return Task.Run(() =>
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View();
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

    }
}