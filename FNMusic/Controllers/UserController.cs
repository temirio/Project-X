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
        private string accessToken;

        public UserController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;

            accessToken = httpContextAccessor.HttpContext.Session.GetString("X-AUTH-TOKEN");
        }

        [Route("{username}/updateprofile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string username)
        {
            User user = await userService.FindUserByUsername(username, accessToken);

            if (!username.Equals(user.username))
            {
                return View("pagenotfound");
            }

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
                Response.Redirect("/pagenotfound");
            }      

            return View(user);

        }

    }
}