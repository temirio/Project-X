using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaseLib.Models;
using FNMusic.Models.Auth;
using FNMusic.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UserMgt.Services;
using UserMgt.Utils;

namespace FNMusic.Controllers
{
    [Route("/")]
    public class AuthController : Controller
    {
        private IAuthService authService;
        private SessionUtils sessionUtils;

        public AuthController(IAuthService authService)
        {    
            this.authService = authService;
            this.sessionUtils = new SessionUtils();
        }

        [Route("register")]
        public IActionResult Register()
        {
            HttpContext.Session.Clear();
            List<SelectListItem> GenderList = new List<SelectListItem>() {
                new SelectListItem(){ Text = "Select Gender", Value = null, Selected = true },
                new SelectListItem(){ Text = "Male", Value = "M" },
                new SelectListItem(){ Text = "Female", Value = "F" },
                new SelectListItem(){ Text = "Unspecified", Value = "U", Disabled = true }
            };

            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {            
                return View(model).WithWarning("Wrong input", "kindly fill in the correct information"); ;                        
            }

            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Response response = await authService.Register(content);
            while (response != null)
            {
                if (response.Code != "201")
                    break;

                if (response.Token != null)
                {
                    Dictionary<string, string> userDetails = AuthorizeJWToken.Authorize(response.Token);
                    userDetails.Add("X-AUTH-TOKEN", response.Token);

                    foreach (string key in userDetails.Keys)
                    {
                        HttpContext.Session.SetString(key.ToString(), userDetails.GetValueOrDefault(key));
                    }
                    Response.Redirect("/"+userDetails.GetValueOrDefault("username").ToString()+"/updateprofile");
                }
                break;
            }

            return View(model).WithDanger("Service Unavailable", "Sorry we could not log you in right now, try again later");
        }

        [Route("login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";

            HttpContext.Session.Clear();
            return View();
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model).WithWarning("Wrong input","kindly fill in the correct information");
            }

            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Response response = await authService.Login(content);
            while (response != null)
            {
                if (response.Code != "200")
                    break;
                
                if (response.Token != null)
                {
                    Dictionary<string, string> userDetails = AuthorizeJWToken.Authorize(response.Token);
                    userDetails.Add("X-AUTH-TOKEN", response.Token);

                    foreach (string key in userDetails.Keys)
                    {
                        HttpContext.Session.SetString(key.ToString(), userDetails.GetValueOrDefault(key));
                    }
                    Response.Redirect("/discover");
                }
                break;
            }

            return View(model).WithDanger("Service Unavailable","Sorry we could not log you in right now, try again later");
        }

        
    }
}