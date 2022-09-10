using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silas.Service.Persons.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Nome Usuario
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Telefone Usuario
        /// </summary>
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }


       
    }
}
