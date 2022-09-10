using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silas.API.Models;
using Silas.API.Services;
using Silas.Authentication.Models.Auth;
using System;
using System.Threading.Tasks;

namespace Silas.API.Controllers
{
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// Autentica usuário e gera token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Authentication")]
        [ProducesResponseType (typeof (IJWTAuth), 200)]
        [ProducesResponseType (typeof (string), 500)]
        public async Task<object> Authentication([FromBody] AuthenticationModels user)
        {
            try
            {
                AuthenticationServices authentication = new AuthenticationServices();

                return authentication.AuthenticationUser(user);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Atualiza token baseado no token válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("RefreshToken")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> RefreshToken(string token)
        {
            try
            {
                AuthenticationServices authentication = new AuthenticationServices();

                return authentication.RefreshToken(token);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
