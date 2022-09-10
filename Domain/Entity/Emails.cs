using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Emails : Base, IAggregateRoot
    {
        public Guid ClienteId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        
    }
}