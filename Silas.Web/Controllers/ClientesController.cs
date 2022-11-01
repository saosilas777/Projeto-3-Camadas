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
using Silas.Web.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        [HttpGet("HistoricoCliente")]
        public IActionResult HistoricoCliente(int codigo)
        { 
            
            var avm = _services.Cliente(codigo);
            return View("HistoricoCliente", avm);

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
        public dynamic Cliente(int codigo)
        {
            var avm = _services.Cliente(codigo);
            return View("Cliente", avm);
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

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromForm] ClienteViewModel cliente)
        {
            _services.Cadastro(cliente);
            return View("ClienteCadastrado");
        }



        //[HttpPost("CadastrarCliente")]
        //public string CadastrarCliente([FromForm] ClienteViewModel cliente)
        //{
        //}

    }
}

