using Data.Context;
using Domain.Entity;
using Domain.Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Silas.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Silas.API.Models;

namespace Silas.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : Controller
    {
        ClienteServices _clienteServices;

        public ClienteController()
        {
            _clienteServices = new ClienteServices();
        }


        [HttpPost("Create")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> Create([FromBody] ClienteModels cliente)
        {
            try
            {
                var newCliente = _clienteServices.Create(cliente);
                return await Task.FromResult(newCliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpGet("ClientesCadastrados")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> ClientesCadastrados()
        {
            try
            {
                return await _clienteServices.GetAll();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }
        [HttpGet("BuscarCliente")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> BuscarCliente(int codigo)
        {
            try
            {
                return await _clienteServices.GetByCode(codigo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost("NovoRegistroDeCompra")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddCompra([FromBody] HistoricoCompraModel compra)
        {
            try
            {
                var newCompra = _clienteServices.AddCompra(compra);
                return await Task.FromResult(newCompra);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost("NovoRegistroDeContato")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddRegistro([FromBody] HistoricoClienteModel registro)
        {
            try
            {
                var newRegistro = _clienteServices.AddRegistro(registro);
                return await Task.FromResult(newRegistro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost("AdicionarTelefone")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddTelefone(string[] telefone, Guid id)
        {
            var result = _clienteServices.AddTelefone(telefone, id);
            return await Task.FromResult(result);
        }

        [HttpPatch("ChangeTelefoneStatus")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> DisableTelefone(Guid id, bool isActive)
        {
            var result = _clienteServices.DisableTelefone(id, isActive);
            return await Task.FromResult(result);
        }

        [HttpPatch("ChangeEmailStatus")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> DisableEmail(Guid id, bool isActive)
        {
            var result = _clienteServices.DisableEmail(id, isActive);
            return await Task.FromResult(result);
        }

    }
}
