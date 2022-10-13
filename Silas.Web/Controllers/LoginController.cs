using Microsoft.AspNetCore.Mvc;

namespace Silas.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.IsLogin = true;
            return View("_Login");
        }
    }
}
