using Newtonsoft.Json;
using RestSharp;
using Silas.Web.Helpers;
using Silas.Web.Models.ViewModels;
using Silas.Web.Models;
using System.Collections.Generic;

namespace Silas.Web.Services
{
    public class ClienteServices
    {

        public dynamic ListarClientesCadastrados()
        {
            string url = "https://localhost:5001/Cliente/ClientesCadastrados";
            return HttpHelper.GET(url).Content;
        }

        public dynamic BuscarCliente(int codigo)
        {
            string url = $"https://localhost:5001/Cliente/BuscarCliente?codigo={codigo}";
            return HttpHelper.GET(url).Content;
        }

        public dynamic Cliente(int codigo)
        {
            var result = JsonConvert.DeserializeObject<ClienteViewModel>(BuscarCliente(codigo));

            var avm = new ApplicationViewModel
            {
                ClienteViewModel = new ClienteViewModel
                {
                    Codigo = codigo.ToString(),
                    RazaoSocial = result.RazaoSocial,
                    Bairro = result.Bairro,
                    Cidade = result.Cidade,
                    Estado = result.Estado
                }
            };
            return avm;
        }
    }
}

