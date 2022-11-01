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
                    Estado = result.Estado,
                    Contato = result.Contato,
                    HistoricoCliente = result.HistoricoCliente,


                }
            };
            return avm;
        }

        public dynamic Atualizar(ClienteViewModel cliente)
        {
            string url = "https://localhost:5001/Cliente/Atualizar";
            ICollection<EmailsModel> emails = new List<EmailsModel>();
            ICollection<TelefonesModel> tels = new List<TelefonesModel>();

            foreach (var x in cliente.Email)
            {
                emails.Add(new EmailsModel { Email = x, IsActive = true });
            }

            foreach (var x in cliente.Telefone)
            {
                tels.Add(new TelefonesModel { Telefone = x, IsActive = true });
            }





            cliente.Contato = new ContatoModels
            {

                Email = emails,
                Telefone = tels
            };



            return HttpHelper.POST(url, JsonConvert.SerializeObject(cliente));

        }

        public dynamic Cadastro(ClienteViewModel cliente)
        {


            string url = "https://localhost:5001/Cliente/Cadastro";
            ICollection<EmailsModel> emails = new List<EmailsModel>();
            ICollection<TelefonesModel> tels = new List<TelefonesModel>();

            foreach (var x in cliente.Email)
            {
                emails.Add(new EmailsModel { Email = x, IsActive = true });
            }

            foreach (var x in cliente.Telefone)
            {
                tels.Add(new TelefonesModel { Telefone = x, IsActive = true });
            }


            


            cliente.Contato = new ContatoModels
            {

                Email = emails,
                Telefone = tels
            };

            

            return HttpHelper.POST(url, JsonConvert.SerializeObject(cliente));

        }
    }
}

