using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FNMusic.Controllers
{
    [Route("/")]
    public class PlayerController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;

        public PlayerController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor.HttpContext.Session.Keys == null)
            {
                Response.Redirect("http://localhost:5001");
            }
        }

        [Route("discover")]
        public IActionResult Index()
        {
            return View();
        }
    }
}