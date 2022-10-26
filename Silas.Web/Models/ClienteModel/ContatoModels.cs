using System.Collections.Generic;

namespace Silas.Web.Models
{
    public class ContatoModels
    {
        public ICollection<TelefonesModel> Telefone { get; set; }

        public ICollection<EmailsModel> Email { get; set; }
    }
}
