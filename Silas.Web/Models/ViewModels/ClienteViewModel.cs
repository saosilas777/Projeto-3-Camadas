using Silas.API.Models;

namespace Silas.Web.Models.ViewModels
{
    public class ClienteViewModel
    {
        public string Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ContatoModels Contato { get; set; }
        public HistoricoClienteModel HistoricoCliente { get; set; }



    }


}
