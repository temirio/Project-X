using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UserMgt.Models;
using BaseLib.Models;
using BaseLib.Utils;
using UserMgt.Services;

namespace FNMusic.Services
{
    public class SystemService
    {
        private IHttpContextAccessor httpContextAccessor;
        private IUserService<Result<User>> userService;
        private string accessToken;

        public SystemService(IHttpContextAccessor httpContextAccessor, IUserService<Result<User>> userService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
        }

        public async Task UpdateHttpContext()
        {
            ClaimsPrincipal principal = httpContextAccessor.HttpContext.User;
            HttpResult<Result<User>> httpResult = null;

            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                accessToken = principal.Claims.First(x => x.Type == "X-AUTH-TOKEN").Value;
            }

            long id = long.Parse(principal.Claims.First(x => x.Type == "Id").Value);
            httpResult = await userService.FindUserById(id, accessToken);
            if (!HttpStatusUtils.Is2xxSuccessful(httpResult.Status))
            {
                throw new Exception(httpResult.FailureResponse.Description);
            }

            Result<User> result = httpResult.Content;
            User user = result.Data;
            Feature feature = JsonConvert.DeserializeObject<Feature>(principal.Claims.First(x => x.Type == "Feature").Value);
            string refreshToken = principal.Claims.First(x => x.Type == "X-AUTH-REFRESH").Value ?? "";

            await SetHttpContext(user, feature, accessToken, refreshToken);
        }

        public async Task SetHttpContext(User user, Feature feature, string accessToken, string refreshToken)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email ?? ""),
                new Claim("EmailConfirmed", user.EmailConfirmed.ToString()),
                new Claim("Username", user.Username),
                new Claim("Phone", user.Phone ?? ""),
                new Claim("PhoneConfirmed", user.PhoneConfirmed.ToString()),
                new Claim("TwoFactorEnabled", user.TwoFactorEnabled.ToString()),
                new Claim("PasswordResetProtection", user.PasswordResetProtection.ToString()),
                new Claim("Country", user.Nationality ?? ""),
                new Claim("X-AUTH-TOKEN", accessToken),
                new Claim("X-AUTH-REFRESH", refreshToken),
                new Claim("Feature", JsonConvert.SerializeObject(feature))
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                await httpContextAccessor.HttpContext.SignOutAsync();
            }

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }
    }
}
