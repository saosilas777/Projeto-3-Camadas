using Silas.API.Services;
using Silas.API.Models;
using Silas.Web.Models.ViewModels;
using Silas.API.Services;
using System.Collections.Generic;

namespace Silas.Web.WebServices
{
    public class WebServices
    {
        ClienteServices _clienteServices;

        public WebServices()
        {
            _clienteServices = new ClienteServices();
        }

        public string Create(ClienteViewModel cliente)
        {
            ClienteModels clienteModel = new ClienteModels();
            clienteModel.Codigo = int.Parse(cliente.Codigo);
            clienteModel.RazaoSocial = cliente.RazaoSocial;
            clienteModel.Bairro = cliente.Bairro;
            clienteModel.Cidade = cliente.Cidade;
            clienteModel.Estado = cliente.Estado;
            
            


            return _clienteServices.Create(clienteModel);
        }
    }
}
