using Microsoft.AspNetCore.Mvc;
using MVCNew_project.Models;
using static System.Net.WebRequestMethods;

namespace MVCNew_project.Controllers
{
    public class UtilityController : Controller
    {
        Utility u = new Utility();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login( string Username, string Password)
        {
            Response.Cookies.Append("Username", Username);
            Response.Cookies.Append("Password", Password);


           // HttpContext.Session.SetString("username", username);
            return View();
        }
        public IActionResult Check()
        {
            string username = Request.Cookies["Username"];
            string Pass = Request.Cookies["Password"];

           // string username= HttpContext.Session.GetString("username")
;

            return Content($"UserName is => {username}");
        }
        public IActionResult View1()
        {
            TempData["id"] = 3;
            return View();
        }

    }
}
