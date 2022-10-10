using Microsoft.AspNetCore.Mvc;

namespace Silas.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
