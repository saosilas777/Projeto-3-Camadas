using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Silas.Web.Models.ViewModels;

namespace Silas.Web.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost("CadastrarCliente")]
        public async Task<object> CadastrarCliente([FromForm] ClienteViewModel cliente)
        {
            return await Task.FromResult(cliente);

        }
    }
}
