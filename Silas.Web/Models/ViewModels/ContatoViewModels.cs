using Silas.API.Models;
using System.Collections.Generic;

namespace Silas.Web.Models.ViewModels
{
    public class ContatoViewModels
    {
        public ICollection<TelefonesModel> Telefone { get; set; }

        public ICollection<EmailsModel> Email { get; set; }
    }
}
