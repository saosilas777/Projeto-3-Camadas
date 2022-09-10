using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class HistoricoCliente : Base, IAggregateRoot
    {
        public Guid ClienteId { get; set; }
        public DateTime Data { get; set; }
        public string RegistroDeContato { get; set; }
        public bool IsActive { get; set; }
       
   
    }
}
