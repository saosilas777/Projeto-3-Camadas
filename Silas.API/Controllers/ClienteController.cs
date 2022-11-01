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

        #region Metodos

        /// <summary>
        /// Criação de um modelo de cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost("Cadastro")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> Cadastro([FromBody] ClienteModel cliente)
        {
            try
            {
                var newCliente = _clienteServices.Cadastro(cliente);
                return await Task.FromResult(newCliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpPost("Atualizar")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> Atualizar([FromBody] ClienteModel cliente)
        {
            try
            {
                var newCliente = _clienteServices.Atualizar(cliente);
                return await Task.FromResult(newCliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        /// <summary>
        /// Lista de clientes cadastrados
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Busca um cliente baseado em seu código de cliente
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Registra a compra de um cliente baseado no seu codigo de cliente
        /// </summary>
        /// <param name="compra"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpPost("NovoRegistroDeCompra")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddCompra([FromBody] HistoricoCompraModel compra, int codigo)
        {
            try
            {
                var newCompra = _clienteServices.AddCompra(compra, codigo);
                return await Task.FromResult(newCompra);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        /// <summary>
        /// Registra o contato realizado em um cliente baseado no codigo de cliente
        /// </summary>
        /// <param name="registro"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>

        [HttpPost("NovoRegistroDeContato")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddRegistro([FromBody] HistoricoContatoModel registro, int codigo)
        {
            try
            {
                var newRegistro = _clienteServices.AddRegistro(registro, codigo);
                return await Task.FromResult(newRegistro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        /// <summary>
        /// Busca um registro de contato de um cliente com base em seu codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("BuscarRegistroContato")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> RegistroContato(int codigo)
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

        /// <summary>
        /// Registra um ou mais telefones para cliente cadastrado com base no seu codigo
        /// </summary>
        /// <param name="telefone"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>

        [HttpPost("AdicionarTelefone")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddTelefone(string[] telefone, int codigo)
        {
            var result = _clienteServices.AddTelefone(telefone, codigo);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Registra um ou mais emails para cliente cadastrado com base no seu codigo
        /// </summary>
        /// <param name="email"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>

        [HttpPost("AdicionarEmail")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> AddEmail(string[] email, int codigo)
        {
            var result = _clienteServices.AddEmail(email, codigo);
            return await Task.FromResult(result);
        }

        //TODO
        //fazer o metodo desabilitar um telefone especifico

        /// <summary>
        /// Ativa ou inativa um telefone cadastrado com base no codigo do cliente
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        [HttpPatch("MudarStatusTelefone")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> DisableTelefone(int codigo, bool isActive)
        {
            var result = _clienteServices.DisableTelefone(codigo, isActive);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Ativa ou inativa um email cadastrado com base no codigo do cliente
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        [HttpPatch("MudarStatusEmail")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> DisableEmail(int codigo, bool isActive)
        {
            var result = _clienteServices.DisableEmail(codigo, isActive);
            return await Task.FromResult(result);
        }
        #endregion



    }
}