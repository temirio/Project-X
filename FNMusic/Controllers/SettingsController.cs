using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using BaseLib.Models;
using BaseLib.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMgt.Models;
using UserMgt.Services;
using UserMgt.Utils;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using FNMusic.Utils;
using FNMusic.Services;
using FNMusic.Models;

namespace FNMusic.Controllers
{
    [Authorize]
    [Route("/settings/")]
    public class SettingsController : Controller
    {

        private readonly IUserService<Result<User>> userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAccountSettingsService<ServiceResponse> accountSettingsService;
        private SystemService systemService;
        private readonly string accessToken;
        private readonly string email;

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
            email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;

        }

        [Authorize]
        [Route("account")]
        public async Task<IActionResult> AccountSettings()
        {
            try
            {
                long userId = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);
                HttpResult<Result<User>> httpResult = await userService.FindUserById(userId, accessToken);
                if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                {
                    throw new Exception(httpResult.FailureResponse.Description);
                }

                Result<User> result = httpResult.Content;
                User user = result.Data;

                return View(user);
            }
            catch (Exception e)
            {
                return View().WithDanger("Oops", e.Message);
            }
        }

        [NonAction]
        public async Task UpdateHttpContext()
        {
            try
            {
                long userId = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);
                HttpResult<Result<User>> httpResult = await userService.FindUserById(userId, accessToken);
                if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                {
                    throw new Exception(httpResult.FailureResponse.Description);
                }

                Result<User> result = httpResult.Content;
                User updatedUser = result.Data;
                Feature feature = JsonConvert.DeserializeObject<Feature>(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Feature").Value);
                string refreshToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-REFRESH").Value;
                await systemService.SetHttpContext(updatedUser, feature, accessToken, refreshToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Authorize]
        [Route("account/username")]
        public async Task<IActionResult> UpdateUsername()
        {
            try
            {
                HttpResult<Result<User>> httpResult = await userService.FindUserByEmail(email, accessToken);
                if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                {
                    throw new Exception(httpResult.FailureResponse.Description);
                }
                Result<User> result = httpResult.Content;
                User user = result.Data;
                return View(user);
            }
            catch (Exception e)
            {
                return View().WithDanger("Oops",e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("account/username")]
        public async Task<IActionResult> UpdateUsername(User user)
        {
            return await Task.Run(async () => 
            {
                try
                {
                    string username = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value;
                    if (user.Username == username)
                    {
                        throw new Exception("You need to change your username");
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdateUsernameAsync(user.Username, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops",e.Message);
                }
            });
        }

        [Authorize]
        [Route("account/phone")]
        public async Task<IActionResult> UpdatePhone()
        {
            return await Task.Run(() => 
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View(new Update());
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [HttpPost]
        [Route("account/phone")]
        public async Task<IActionResult> UpdatePhone(Update update)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    bool VerificationCodeSent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("VCSent"));
                    if (!VerificationCodeSent)
                    {
                        HttpResult<ServiceResponse> result = await accountSettingsService.SendPhoneVerificationTokenAsync(update.Phone, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
                        return View(update);
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdatePhoneAsync(update.Phone, update.Token, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [Route("account/email")]
        public async Task<IActionResult> UpdateEmail()
        {
            return await Task.Run(() =>
            {
                try
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View(new Update());
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

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
                        HttpResult<ServiceResponse> result = await accountSettingsService.SendEmailVerificationTokenAsync(update.Email, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("VCSent", true.ToString());
                        return View(update);
                    }

                    HttpResult<ServiceResponse> httpResult = await accountSettingsService.UpdateEmailAsync(update.Email, update.Token, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }
                    await UpdateHttpContext();
                    return Redirect("/settings/account");
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

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

        [Authorize]
        [HttpPost("account/password")]
        public async Task<IActionResult> UpdatePassword(UpdatePassword updatePassword)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Kindly fill in all required information");
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

        [Authorize]
        [Route("account/twofactor")]
        public async Task<IActionResult> UpdateTwofactor()
        {
            return await Task.Run(() => 
            {
                try
                {
                    bool isTwoFactorEnabled = Convert.ToBoolean(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "TwoFactorEnabled").Value);
                    httpContextAccessor.HttpContext.Session.Clear();
                    return View(new UpdateTwoFactor()
                    {
                        Enabled = isTwoFactorEnabled,
                        VerificationMethod = VerificationMethod.TextMessage
                    });
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops", e.Message);
                }
            });
        }

        [Authorize]
        [HttpPost]
        [Route("account/twofactor/{Status}")]
        public async Task<IActionResult> UpdateTwoFactor(UpdateTwoFactor updateTwoFactor)
        {
            if (!ModelState.IsValid)
            {
                return View().WithDanger("Invalid Request", "");
            }

            return await Task.Run(async () =>
            {
                try
                {
                    
                    string phone = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Phone").Value;
                    if (string.IsNullOrEmpty(phone))
                    {
                        throw new Exception("You have not submitted a valid phone number");
                    }

                    bool twofactorVerificationSent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("TWFVS"));
                    if (!twofactorVerificationSent && updateTwoFactor.Enabled)
                    {
                        HttpResult<ServiceResponse> result = await accountSettingsService.SendTwoFactorVerificationTokenAsync(phone, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        httpContextAccessor.HttpContext.Session.SetString("TWFVS", true.ToString());
                        return View();
                    }

                    if (twofactorVerificationSent || !updateTwoFactor.Enabled)
                    {
                        HttpResult<ServiceResponse> result = await accountSettingsService.UpdateTwoFactorAsync(updateTwoFactor.Enabled, updateTwoFactor.Token, accessToken);
                        if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                        {
                            throw new Exception(result.FailureResponse.Description);
                        }
                        return Redirect("/settings/account");
                    }

                    return View(updateTwoFactor);
                }
                catch (Exception e)
                {
                    return View().WithDanger("Oops",e.Message);
                }
            });
        }

        [Authorize]
        [Route("account/password/reset/protection")]
        public async Task<IActionResult> UpdatePasswordResetProtection()
        {
            try
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return View(new Update());
            }
            catch (Exception e)
            {
                return View().WithDanger("Oops", e.Message);
            }
        }

        [Authorize]
        [Route("account/country")]
        public async Task<IActionResult> UpdateCountry()
        {
            try
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return View(new Update());
            }
            catch (Exception e)
            {
                return View().WithDanger("Oops", e.Message);
            }
        }

        [Authorize]
        [Route("account/deactivate")]
        public async Task<IActionResult> DeactivateAccount()
        {
            try
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return View(new Update());
            }
            catch (Exception e)
            {
                return View().WithDanger("Oops", e.Message);
            }
        }

    }
}