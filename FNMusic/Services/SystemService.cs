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

namespace FNMusic.Services
{
    public class SystemService
    {
        private IHttpContextAccessor httpContextAccessor;

        public SystemService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task SetHttpContext(User user, Feature feature, string accessToken, string refreshToken)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("EmailConfirmed", user.EmailConfirmed.ToString()),
                new Claim("Username", user.Username),
                new Claim("Phone", user.Phone),
                new Claim("PhoneConfirmed", user.PhoneConfirmed.ToString()),
                new Claim("TwoFactorEnabled", user.TwoFactorEnabled.ToString()),
                new Claim("X-AUTH-TOKEN",accessToken),
                new Claim("X-AUTH-REFRESH",refreshToken),
                new Claim("Feature",JsonConvert.SerializeObject(feature))
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
