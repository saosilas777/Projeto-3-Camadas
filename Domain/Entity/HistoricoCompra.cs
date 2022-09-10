using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class HistoricoCompra : Base, IAggregateRoot
    {
        public Guid ClienteId { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public bool IsActive { get; set; }
        
    }
}