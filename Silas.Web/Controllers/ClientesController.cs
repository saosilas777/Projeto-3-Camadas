using Microsoft.AspNetCore.Mvc;
using Silas.Web.Models.ViewModels;
using System.Threading.Tasks;
using Silas.Web.WebServices;
using Silas.API.Models;
using System.Linq;
using Domain.Entity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Silas.API.Services;
using System;

namespace Silas.Web.Controllers
{
    public class ClientesController : Controller
    {
        WebServices.WebServices _services;

        public ClientesController()
        {
            _services = new WebServices.WebServices();
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult About()
        {
            return View("About");
        }

        [HttpPost("CadastrarCliente")]
        public string CadastrarCliente([FromForm] ClienteViewModel cliente)
        {
                       
             return _services.Create(cliente);
            
        }
       
    }
}
