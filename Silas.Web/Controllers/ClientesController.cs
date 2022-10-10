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
    public class ClientesController : Controller
    {
        ClienteServices _services;

        public ClientesController()
        {
            _services = new ClienteServices();
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult About()
        {
            return View("About");
        }
        public IActionResult Clientes()
        {
            return View("Clientes");
        }

       


        //[HttpPost("CadastrarCliente")]
        //public string CadastrarCliente([FromForm] ClienteViewModel cliente)
        //{
        //}

    }
}
