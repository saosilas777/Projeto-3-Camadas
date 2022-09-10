using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Cliente : Base, IAggregateRoot
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool IsActive { get; set; }
    }
}
