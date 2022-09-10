using Silas.Service.Persons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silas.Service.Persons.Interfaces
{
    public interface IPerson
    {
        public Guid Create(PersonDTO person);
        public bool Update(PersonDTO person);
        public PersonDTO Get(Guid id);
        public bool Delete(Guid id);

        public List<PersonDTO> PersonListAll();

    }
}
