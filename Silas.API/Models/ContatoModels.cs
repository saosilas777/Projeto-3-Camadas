using Domain.Entity;
using System.Collections.Generic;

namespace Silas.API.Models
{
    public class ContatoModels
    {
        public ICollection<TelefonesModel> Telefone { get; set; }

        public ICollection<EmailsModel> Email { get; set; }
    }
}
