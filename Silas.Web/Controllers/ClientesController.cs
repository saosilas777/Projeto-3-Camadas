using Microsoft.AspNetCore.Mvc;
using Silas.Web.Models.ViewModels;
using System.Threading.Tasks;
using Silas.Web.Services;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;

namespace Silas.Web.Controllers
{
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        ClienteServices _services;

        public ClientesController()
        {
            _services = new ClienteServices();
        }

        [HttpGet]
        public IActionResult Index(string accessToken)
        {
            
            return View("Index");
        }

        [HttpGet("CadastroCliente")]
        public IActionResult CadastroCliente(string codigo)
        {
            return View("CadastroCliente");
        }
        [HttpGet("About")]
        public IActionResult About()
        {
            return View("About");
        }
        [HttpGet("Clientes")]
        public IActionResult Clientes()
        {

            return View("Clientes");
        }

        [HttpGet("clientesCadastrados")]
        public dynamic ListarClientes()
        {
            return _services.ListarClientes();
        }

        //[HttpPost("CadastrarCliente")]
        //public string CadastrarCliente([FromForm] ClienteViewModel cliente)
        //{
        //}

    }
}
