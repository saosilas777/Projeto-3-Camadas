using Microsoft.AspNetCore.Mvc;
using Silas.Web.Models.ViewModels;
using System.Threading.Tasks;
using Silas.Web.Services;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
        public IActionResult CadastroCliente()
        {
            return View("CadastroCliente");
        }
        [HttpGet("About")]
        public IActionResult About()
        {
            return View("About");
        }
        [HttpGet("ListarClientes")]
        public IActionResult ListarClientes()
        {

            return View("ListarClientes");
        }

        [HttpGet("Cliente")]
        public dynamic Cliente()
        {
            return View("Cliente");

        }

        [HttpGet("BuscarCliente")]
        public dynamic BuscarCliente(int codigo)
        {
            return _services.BuscarCliente(codigo);
            
        }

        [HttpGet("ListarClientesCadastrados")]
        public dynamic ListarClientesCadastrados()
        {
            return _services.ListarClientesCadastrados();
        }



        //[HttpPost("CadastrarCliente")]
        //public string CadastrarCliente([FromForm] ClienteViewModel cliente)
        //{
        //}

    }
}

