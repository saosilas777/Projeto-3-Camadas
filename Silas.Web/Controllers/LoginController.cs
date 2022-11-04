using Microsoft.AspNetCore.Mvc;

namespace Silas.Web.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public IActionResult Login(string response)
        {
            ViewBag.IsLogin = true;
            return View("_Login");
        }
    }
}