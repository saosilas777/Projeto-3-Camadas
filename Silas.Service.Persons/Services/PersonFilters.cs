using Silas.Service.Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silas.Service.Persons.Services
{
    public static class PersonFilters
    {

        public static List<PersonDTO> GetByYear(List<PersonDTO> personDTOs, string year)
        {
            return personDTOs.Where(x => x.Nascimento.Year.ToString() == year).ToList();

        }

        public static List<PersonDTO> GetByName(List<PersonDTO> personDTOs, string nome)
        {
            return personDTOs.Where(x => x.Nome == nome).ToList();

        }
        public static List<PersonDTO> GetByPhone(List<PersonDTO> personDTOs, string telefone)
        {
            return personDTOs.Where(x => x.Telefone == telefone).ToList();

        }
    }
}
