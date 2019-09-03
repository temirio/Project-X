using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BaseLib.Models;
using FNMusic.Utils;
using UserMgt.Services;
using Microsoft.AspNetCore.Authorization;

namespace FNMusic.Controllers
{
    
    public class PlayerController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string accessToken;
        private IUserService<Result<User>> userService;

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
        [Route("/home")]
        public IActionResult Discover()
        {
            return View();
        }

        
    }
}