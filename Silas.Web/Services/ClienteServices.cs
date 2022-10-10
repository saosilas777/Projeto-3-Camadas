using Newtonsoft.Json;
using Silas.Web.Models.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace Silas.Web.Services
{
    public class ClienteServices
    {
        public async Task<ClienteViewModel> GetAllClients()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:5001");
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<ClienteViewModel>(jsonString);
            return jsonObject;
        }
    }
}
