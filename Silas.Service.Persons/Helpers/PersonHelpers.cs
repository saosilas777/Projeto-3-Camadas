using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silas.Service.Persons.Helpers
{
    public class PersonHelpers
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }

    }

    public static class PersonList
    {
        public static List<PersonHelpers> list = new List<PersonHelpers>();
        
    }
}
