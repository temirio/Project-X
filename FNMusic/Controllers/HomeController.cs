using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FNMusic.Models;
using Microsoft.AspNetCore.Http;

namespace FNMusic.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor httpContextAccessor;
        private ISession session;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            session = httpContextAccessor.HttpContext.Session;
            session.Clear();
        }

        [Route("")]
        public IActionResult Index()
        {
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/discover");
            }
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("pagenotfound")]
        public IActionResult PageNotFound()
        {        
            return View();
        }
    }
}
