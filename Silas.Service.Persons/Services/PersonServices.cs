using Silas.Service.Persons.DTO;
using Silas.Service.Persons.Helpers;
using Silas.Service.Persons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Silas.Service.Persons.DTO.PersonDTO;

namespace Silas.Service.Persons.Services
{
    public class PersonServices : IPerson
    {
        public Guid Create(PersonDTO person)
        {
            

            var persons = new PersonHelpers
            {
                Id = Guid.NewGuid(),
                Nome = person.Nome,
                Telefone = person.Telefone,
                Nascimento = person.Nascimento,

            };
            PersonList.list.Add(persons);
            return persons.Id;
        }



        public bool Delete(Guid id)
        {
            var p = PersonList.list.Where(x => x.Id == id).FirstOrDefault();
            PersonList.list.Remove(p);
            return true;
        }

        public PersonDTO Get(Guid id)
        {
            var p = PersonList.list.Where(x => x.Id == id).FirstOrDefault();
            var person = new PersonDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Telefone = p.Telefone,
                Nascimento = p.Nascimento

            };
            return person;
        }

        public List<PersonDTO> PersonListAll()
        {
            var p = PersonList.list;
            var personList = new List<PersonDTO>();

            foreach (var person in p)
            {
                personList.Add(new PersonDTO { Id = person.Id, Nome = person.Nome, Nascimento = person.Nascimento, Telefone = person.Telefone });
            }
            return personList;
        }

        //Metodo não está como imaginava que seria, mas funciona.
        public bool Update(PersonDTO person)
        {
            var p = PersonList.list.Where(x => x.Id == person.Id).FirstOrDefault();
            { 
                p.Nome = person.Nome;
                p.Telefone = person.Telefone;
                p.Nascimento = person.Nascimento;
            };
            return true;

        }



    }
}
