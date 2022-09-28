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
    public class UsersController : Controller
    {

        UserService _userService;


        public UsersController()
        {
            _userService = new UserService();
        }

        //[Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> Create([FromBody] UserModels user)
        {
            try
            {
                var newUser = _userService.Create(user);
                return await Task.FromResult(newUser);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpGet("GetAll")]
        public async Task<object> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpPut("UpDate")]
        public async Task<object> Update(UserModels user)
        {
            _userService.UpDate(user);
            return await Task.FromResult(user);
        }


        [HttpPut("ChangingRules")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> ChangeScope(ScopeAndRoleModels user)
        {
            try
            {
                _userService.ChangingScopeAndRole(user);
                return await Task.FromResult("The user has been updated");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("ChangingPassword")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> ChangingPassword(ChangePasswordModels user)
        {
            try
            {
                _userService.ChangingPassword(user);
                return await Task.FromResult("The user has been updated");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("RecoveryPassword")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<object> PasswordRecovery(string userName)
        {
            try
            {
                _userService.RecoveryPassword(userName);
                return await Task.FromResult("Password has been recovered");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        [HttpPatch("Disable")]
        public async Task<object> Disable(Guid id, bool isActive)
        {
            var result = _userService.Disable(id, isActive);
            return await Task.FromResult(result);
        }

    }







}

