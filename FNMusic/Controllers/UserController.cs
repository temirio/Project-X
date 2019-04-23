using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FNMusic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using UserMgt.Utils;
using UserMgt.Services;
using UserMgt.Models;
using FNMusic.Utils;

namespace FNMusic.Controllers
{
    [Route("/")]
    public class UserController : Controller
    {
        public static List<SelectListItem> countrylist = new List<SelectListItem>();
        private IHttpContextAccessor httpContextAccessor;
        private IUserService userService;
        Dictionary<string, object> userDetails;
        User user;
        private string accessToken;


        public UserController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            this.user = new User();
            this.userDetails = new Dictionary<string, object>();
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;

            if (httpContextAccessor.HttpContext.Session.Keys == null)
            {
                foreach (string key in httpContextAccessor.HttpContext.Session.Keys)
                {
                    userDetails.Add(key, httpContextAccessor.HttpContext.Session.GetString(key));
                }

                user.Username = userDetails.GetValueOrDefault("username").ToString();
                user.FirstName = userDetails.GetValueOrDefault("firstname").ToString();
                user.LastName = userDetails.GetValueOrDefault("lastname").ToString();
                user.Gender = userDetails.GetValueOrDefault("gender").ToString();
                user.Role = userDetails.GetValueOrDefault("role").ToString();
                user.Email = userDetails.GetValueOrDefault("email").ToString();             
            }

            accessToken = httpContextAccessor.HttpContext.Session.GetString("X-AUTH-TOKEN");
            

        }

        [HttpGet]
        [Route("{username}/updateprofile")]
        public IActionResult UpdateProfile([FromRoute] string username)
        {
            
            countrylist.Clear();
            countrylist.Add(new SelectListItem { Text = "Select your Country", Value = null, Disabled = true, Selected = true });
            for (int i = 0; i < Countries.Names.Length; i++)
            {
                countrylist.Add(new SelectListItem { Text = Countries.Names[i], Value = Countries.Abbreviations[i] });
            }
            
            return View(user);
        }

        [Route("{username}")]
        public async Task<IActionResult> Profile([FromRoute] string username)
        {
            ViewData["Title"] = "Profile";
            User user = await userService.FindUserByUsername(username,accessToken);
            if (user == null) {
                return View().WithDanger("Something went wrong", "Kindly refresh this page");
            }
                 

            return View(user);

        }

    }
}