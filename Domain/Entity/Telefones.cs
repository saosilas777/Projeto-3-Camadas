using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Telefones : Base, IAggregateRoot
    {
        public Guid ClienteId { get; set; }
        public string Telefone { get; set; }
        public bool IsActive { get; set; }
       
    }
}
