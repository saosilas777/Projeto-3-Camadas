using Microsoft.AspNetCore.Mvc;

namespace Silas.Web.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult About()
        {
            return View("About");
        }
    }
}
