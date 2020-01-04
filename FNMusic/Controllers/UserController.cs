using FNMusic.Models;
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
using BaseLib.Models;
using BaseLib.Utils;
using System.Threading;
using UserMgt.Models;

namespace FNMusic.Controllers
{
    public class UserController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;
        private IUserService<Result<User>> userService;
        private SystemService systemService;
        private IObjectConverter<byte[]> objectConverter;
        private readonly string accessToken;
        
        private static readonly Encoding encoding = Encoding.UTF8;

        public UserController(
            IHttpContextAccessor httpContextAccessor, 
            IUserService<Result<User>> userService, 
            SystemService systemService,
            IObjectConverter<byte[]> objectConverter)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
            this.systemService = systemService;
            this.objectConverter = objectConverter;
            accessToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-TOKEN").Value;
            
        }

        [Authorize]
        [Route("/{Username}")]
        public async Task<IActionResult> Profile([FromRoute(Name = "Username")] string username)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.FindUserByUsername(username,accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }

                    Result<User> result = httpResult.Content;
                    User user = result.Data;
                    if (user == null ||
                        user.Username == null ||
                        username != user.Username)
                    {
                        throw new Exception("user not found");
                    }

                    return View(user);
                }
                catch (Exception ex)
                {
                    return View().WithDanger("Oops", ex.Message);
                }
            });
        }

        [Authorize]
        [Route("/{Username}/updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromRoute(Name = "Username")] string username)
        {
            if (username != httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value)
            {
                return Redirect("/discover");
            }

            return await Task.Run(async () =>
            {
                try
                {
                    HttpResult<Result<User>> httpResult = await userService.FindUserByUsername(username,accessToken);
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
        [HttpPost("/{Username}/updateprofile")]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            user.Id = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            user.Email = Convert.ToString(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value);
            user.Username = Convert.ToString(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value);

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

                    await userService.UpdateProfile(multipart, accessToken);
                    HttpResult<Result<User>> httpResult = await userService.FindUserByEmail(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value, accessToken);
                    if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
                    {
                        throw new Exception(httpResult.FailureResponse.Description);
                    }

                    Result<User> result = httpResult.Content;
                    User updatedUser = result.Data;
                    Feature feature = JsonConvert.DeserializeObject<Feature>(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Feature").Value);
                    string refreshToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-REFRESH").Value ?? null;
                    await systemService.SetHttpContext(updatedUser, feature, accessToken, refreshToken);
                    return (ActionResult) Redirect("/" + httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value + "");
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
                    Thread thread = new Thread(async() => { await userService.LogOut(accessToken); });
                    await HttpContext.SignOutAsync();
                    return Redirect("/login");
                }
                catch
                {
                    return Redirect("/discover");
                }
            });
        }
    } 
}