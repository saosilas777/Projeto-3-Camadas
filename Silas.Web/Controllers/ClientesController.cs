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


        //metodo somente para chamar a pagina
        [HttpGet("CadastroCliente")]
        public IActionResult CadastroCliente()
        {
            return View("CadastroCliente");
        }
        
        [HttpGet("ListarClientes")]
        public IActionResult ListarClientes()
        {

            return View("ListarClientes");
        }
        [HttpGet("ClienteUpdate")]
        public IActionResult ClienteUpdate(int codigo)
        {
            var avm = _services.Cliente(codigo);
            return View("ClienteUpdate",avm);
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

        [HttpPost("Atualizar")]
        public IActionResult Atualizar([FromForm] ClienteViewModel cliente)
        {
            _services.Atualizar(cliente);
            return View("ClienteCadastrado");
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int codigo)
        {
            var avm = _services.Cliente(codigo);
            return View("Delete", avm);
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar(ClienteViewModel cliente)
        {
            
            _services.Delete(int.Parse(cliente.Codigo));
            return View("Deletado");
        }

        [HttpGet("RegistroContato")]
        public IActionResult RegistroContato(int codigo)
        {
            var avm = _services.Cliente(codigo);
            return View("RegistroContato", avm);


        }

        [HttpPost("RegistrarContato")]
        public dynamic RegistrarContato(HistoricoContatoViewModel registro)
        {
             _services.AddRegistro(registro);
            var avm = _services.Cliente(int.Parse(registro.Codigo));
            return View("Cliente", avm);
        }
    }
}

