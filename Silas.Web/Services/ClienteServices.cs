using Newtonsoft.Json;
using RestSharp;
using Silas.Web.Helpers;
using Silas.Web.Models.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Silas.Web.Services
{
    public class ClienteServices
    {
        
        public dynamic ListarClientes()
        {
            string url = "https://localhost:5001/Cliente/ClientesCadastrados";
            return HttpHelper.GET(url).Content;
        }
    }
}
