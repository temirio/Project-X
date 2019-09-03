using BaseLib.Models;
using BaseLib.Utils;
using FNMusic.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

namespace FNMusic.Controllers
{

    [Route("/")]
    public class UserController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;
        private IUserService<Result<User>> userService;
        private IObjectConverter<byte[]> objectConverter;
        private readonly string accessToken;
        
        private static Encoding encoding = Encoding.UTF8;

        public UserController(IHttpContextAccessor httpContextAccessor, IUserService<Result<User>> userService, IObjectConverter<byte[]> objectConverter)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
            this.objectConverter = objectConverter;
            accessToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-TOKEN").Value;
            
        }

        [Authorize]
        [Route("{username}")]
        public async Task<IActionResult> Profile([FromRoute] string username)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.FindUserByUsername(username);
                    if (httpResult.Content == null)
                    {
                        return Redirect("/pagenotfound");
                    }

                    User user = httpResult.Content.Data;
                    if (username != user.Username)
                    {
                        return Redirect("/pagenotfound");
                    }

                    return View(user);
                }
                catch (Exception ex)
                {
                    return Redirect("/pagenotfound").WithDanger("Oops", ex.Message);
                }
            });
        }

        [NonAction]
        public Task UpdateHttpContext(User user)
        {
            return Task.Run(async() =>
            {
                string jsonObject = JsonConvert.SerializeObject(user);
                JObject jObject = JObject.Parse(jsonObject);

                List<Claim> claims = new List<Claim>();
                foreach (var x in jObject)
                {
                    claims.Add(new Claim(x.Key, x.Value.ToString()));
                }

                ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
                ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;
                string feature = identity.Claims.First(X => X.Type == "Feature").Value;
                claims.Add(new Claim("Feature", feature));
                claims.Add(new Claim("X-AUTH-TOKEN", accessToken));

                identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                principal = new ClaimsPrincipal(identity);

                await httpContextAccessor.HttpContext.SignOutAsync();
                await httpContextAccessor.HttpContext.SignInAsync(principal);
            });
        }

        [Authorize]
        [Route("{username}/updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string username)
        {
            if (username != httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value)
            {
                return Redirect("/pagenotfound");
            }

            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.FindUserByUsername(username);
                    if (httpResult.Content == null)
                    {
                        throw new Exception();
                    }

                    User user = httpResult.Content.Data;
                    if (!username.Equals(user.Username))
                    {
                        throw new Exception();
                    }

                    return View(user);
                }
                catch
                {
                    return (IActionResult) Redirect("/" + httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value);
                }
            });
        }

        [Authorize]
        [HttpPost("{username}/updateprofile")]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            user.Email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "kindly fill in all necessary information");
                return View(user);
            }

            return await Task.Run(async () =>
            {
                try
                {
                    string jsonRequest = JsonConvert.SerializeObject(user);
                    HttpContent requestContent = new StringContent(jsonRequest);
                    var multipart = new MultipartFormDataContent
                    {
                        { requestContent, "Request" }
                    };

                    if (user.ProfilePhoto != null)
                    {
                        multipart.Add(new ByteArrayContent(objectConverter.ObjectToValueConverter(user.ProfilePhoto)), "ProfilePhoto");
                    }

                    if (user.CoverPhoto != null)
                    {
                        multipart.Add(new ByteArrayContent(objectConverter.ObjectToValueConverter(user.CoverPhoto)), "CoverPhoto");
                    }

                    
                    await userService.UpdateProfile(multipart, accessToken).ConfigureAwait(false);
                    List<Claim> claims = httpContextAccessor.HttpContext.User.Claims.ToList();
                    user.Id = Convert.ToInt64(claims.First(x => x.Type == "Id").Value);
                    user.EmailConfirmed = Convert.ToBoolean(claims.First(x => x.Type == "EmailConfirmed").Value);
                    user.Role = (Role) Enum.Parse(typeof(Role), claims.First(x => x.Type == "Role").Value);
                    user.Verified = Convert.ToBoolean(claims.First(x => x.Type == "Verified").Value);
                    user.DateCreated = Convert.ToDateTime(claims.First(x => x.Type == "DateCreated").Value);
                    await UpdateHttpContext(user).ConfigureAwait(false);
                    
                    return (ActionResult) Redirect("/" + user.Username + "");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(user);
                }
            });
        }

        [Authorize]
        [HttpPost]
        [Route("/follow")]
        public async Task<IActionResult> FollowUser([FromQuery(Name = "userId")] long userId, [FromQuery(Name = "fanId")] long fanId)
        {
            try
            {
                long currentUserId = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(X => X.Type == "Id").Value);
                if (fanId.Equals(currentUserId))
                {
                    await Task.Run(async() => { await userService.FollowUser(userId, fanId, accessToken); });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPost]
        [Route("/unfollow")]
        public async Task<IActionResult> UnfollowUser([FromQuery(Name = "userId")] long userId, [FromQuery(Name = "fanId")] long fanId)
        {
            try
            {
                long currentUserId = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(X => X.Type == "Id").Value);
                if (fanId.Equals(currentUserId))
                {
                    await Task.Run(async() => { await userService.UnfollowUser(userId, fanId, accessToken); });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [NonAction]
        [Route("/isfollower")]
        public async Task<Result<User>> IsFollower([FromQuery(Name = "userId")] long userId, [FromQuery(Name = "fanId")] long fanId)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.IsFollower(userId, fanId, accessToken);
                    return httpResult.Content;
                }
                catch
                {
                    return null;
                }
            });
        }

        [Authorize]
        [Route("/isfollowing")]
        public async Task<Result<User>> IsFollowing([FromQuery(Name = "userId")] long userId, [FromQuery(Name = "fanId")] long fanId)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.IsFollowing(userId, fanId, accessToken);
                    return httpResult.Content;
                }
                catch
                {
                    return null;
                }
            });
        }

        [Authorize]
        [HttpGet]
        [Route("/followers")]
        public async Task<Result<User>> GetFollowers(long userId, int pageNumber, int pageSize)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.GetFollowers(userId, pageNumber, pageSize, accessToken);
                    return httpResult.Content;
                }
                catch
                {
                    return null;
                }
            });
        }

        [Authorize]
        [HttpGet]
        [Route("/following")]
        public async Task<Result<User>> GetFollowing(long userId, int pageNumber, int pageSize)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.GetFollowing(userId, pageNumber, pageSize, accessToken);
                    return httpResult.Content;
                }
                catch
                {
                    return null;
                }
            });
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            return await Task.Run(async () => 
            {
                try
                {
                    HttpResult<Result<User>> result = await userService.LogOut(accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(result.Status))
                    {
                        ServiceResponse response = result.FailureResponse;
                        throw new Exception(response.Description);
                    }

                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        await HttpContext.SignOutAsync();
                    }

                    return Redirect("/");
                }
                catch (Exception ex)
                {
                    return Redirect("/discover").WithDanger("Oops",ex.Message);
                }
            });
        }
    } 
}