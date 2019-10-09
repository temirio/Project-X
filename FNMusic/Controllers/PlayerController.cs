using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserMgt.Models;
using UserMgt.Services;
using Microsoft.AspNetCore.Authorization;
using BaseLib.Models;

namespace FNMusic.Controllers
{

    public class PlayerController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserService<Result<User>> userService;
        private readonly string accessToken;

        public PlayerController(IHttpContextAccessor httpContextAccessor, IUserService<Result<User>> userService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
            accessToken = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "X-AUTH-TOKEN").Value;

            var session = httpContextAccessor.HttpContext.Session;
            bool TFE = Convert.ToBoolean(session.GetString("TFE"));
            bool TFV = Convert.ToBoolean(session.GetString("TFV"));
            if (TFE && !TFV)
            {
                httpContextAccessor.HttpContext.Response.Redirect("/login/verification");
            }
            
        }

        [Authorize]
        [Route("/discover")]
        public IActionResult Discover()
        {
            return View();
        }

        
    }
}