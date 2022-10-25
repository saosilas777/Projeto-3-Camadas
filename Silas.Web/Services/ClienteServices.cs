using RestSharp;
using Silas.Web.Helpers;

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
    }
}

