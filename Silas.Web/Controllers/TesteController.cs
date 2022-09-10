using Microsoft.AspNetCore.Mvc;

namespace Silas.Web.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
