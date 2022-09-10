using Microsoft.AspNetCore.Mvc;
using Silas.Service.Persons.Services;
using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Silas.API.Controllers.Persons
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonsController : ControllerBase
    {

        #region Person
        private readonly IPerson _person;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger, IPerson person)
        {
            _person = person;
            _logger = logger;
        }

        /// <summary>
        /// Create person method
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>

        [HttpPost("Create")]
        
        public async Task<object> Create([FromBody] PersonDTO person)
        {
            try
            {
                _logger.LogDebug("Criando novo usuario");

                var result = _person.Create(person);
                //var regex = Regex.IsMatch(result.ToString(), "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$");

                if (!Regex.IsMatch(result.ToString(), "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$"))
                    throw new Exception("Não foi possivel cadastrar usuario | Guid inválido");

                _logger.LogInformation("Usuario cadastrado com sucesso");
                return await Task.FromResult(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return e.Message;

            }

        }

        /// <summary>
        /// Method to get person by Id type Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPerson")]
        public async Task<object> GetPerson(string id)
        {
            var get = _person.Get(Guid.Parse(id));
            return await Task.FromResult(get);
        }

        [HttpDelete("DeletePerson")]
        public async Task<object> DeletePerson(string id)
        {
            var delete = _person.Delete(Guid.Parse(id));
            return await Task.FromResult(delete);
        }


        [HttpGet("All")]
        public async Task<object> All()
        {
            var all = _person.PersonListAll();
            return await Task.FromResult(all);
        }

        [HttpGet("GetByYear")]
        public async Task<object> GetByYear(string year)
        {
            var persons = PersonFilters.GetByYear(_person.PersonListAll(), year);
            return await Task.FromResult(persons);
        }

        [HttpGet("GetByName")]
        public async Task<object> GetByName(string nome)
        {
            var persons = PersonFilters.GetByName(_person.PersonListAll(), nome);
            return await Task.FromResult(persons);
        }

        [HttpGet("GetByPhone")]
        public async Task<object> GetByPhone(string phone)
        {
            var persons = PersonFilters.GetByPhone(_person.PersonListAll(), phone);
            return await Task.FromResult(persons);
        }

        [HttpPut("UpDate")]
        public async Task<object> Update([FromBody] PersonDTO person)
        {
            var result = _person.Update(person);
            return await Task.FromResult(result);
        }
        #endregion

    }
}
