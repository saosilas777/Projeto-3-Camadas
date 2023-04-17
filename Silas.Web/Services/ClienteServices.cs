using Newtonsoft.Json;
using RestSharp;
using Silas.Web.Helpers;
using Silas.Web.Models.ViewModels;
using Silas.Web.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using Microsoft.Extensions.Configuration;

namespace Silas.Web.Services
{
    public class ClienteServices
    {
        public string changeUrl() {

            string url = "http://192.168.15.100:9999/";
            //string url = "https://localhost:5001/";

            return url;

        }

       
        public dynamic ListarClientesCadastrados()
        {
            string url = changeUrl() + "Cliente/ClientesCadastrados";
            return HttpHelper.GET(url).Content;
        }


        public dynamic BuscarCliente(int codigo)
        {
            string url = $"{changeUrl()}Cliente/BuscarCliente?codigo={codigo}";
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
            string url = changeUrl() + "Cliente/Atualizar";
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

        public dynamic Delete(int codigo)
        {
            string url = $"{changeUrl()}Cliente/Delete?codigo={codigo}";
            return HttpHelper.POST(url, codigo);

        }
        public dynamic Cadastro(ClienteViewModel cliente)
        {


            string url = changeUrl() + "Cliente/Cadastro";
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

        public EmailsModel Email(string email)
        {
            var mail = new EmailsModel { Email = email, IsActive = true };
            return mail;
        }

        public dynamic AddRegistro(HistoricoContatoViewModel resgistro)
        {
            var code = resgistro.Codigo;
            string url = $"{changeUrl()}Cliente/RegistroContato?codigo={code}";
            var reg = new HistoricoContatoModel { RegistroDeContato = resgistro.RegistroDeContato, Data = DateTime.Now };
            //var reg = new HistoricoContatoModel { RegistroDeContato = resgistro};
            

            return HttpHelper.POST(url, JsonConvert.SerializeObject(reg));


        }
    }
}

