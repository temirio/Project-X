using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FNMusic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using UserMgt.Utils;

namespace FNMusic.Controllers
{
    [Route("/")]
    public class UserController : Controller
    {
        public static List<SelectListItem> countrylist = new List<SelectListItem>();
        private IHttpContextAccessor httpContextAccessor;
        Dictionary<string, object> userDetails;
        User user;


        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            this.user = new User();
            this.userDetails = new Dictionary<string, object>();
            this.httpContextAccessor = httpContextAccessor;

            while (httpContextAccessor.HttpContext.Session.Keys == null)
            {
                foreach (string key in httpContextAccessor.HttpContext.Session.Keys)
                {
                    userDetails.Add(key, httpContextAccessor.HttpContext.Session.GetString(key));
                }

                //user.Id = (long) userDetails.GetValueOrDefault("id");
                user.Username = userDetails.GetValueOrDefault("username").ToString();
                user.FirstName = userDetails.GetValueOrDefault("firstname").ToString();
                user.LastName = userDetails.GetValueOrDefault("lastname").ToString();
                user.Gender = userDetails.GetValueOrDefault("gender").ToString();
                //user.DateOfBirth = (DateTime) userDetails.GetValueOrDefault("dateofbirth");
                user.Role = userDetails.GetValueOrDefault("role").ToString();
                user.Email = userDetails.GetValueOrDefault("sub").ToString();
                break;
            }
            

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

        [HttpGet]
        [Route("{username}")]
        public IActionResult Profile([FromRoute] string username)
        {
            ViewData["Title"] = "Profile";

            return View(user);
        }

    }
}