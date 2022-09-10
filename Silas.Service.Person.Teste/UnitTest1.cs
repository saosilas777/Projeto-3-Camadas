using NUnit.Framework;
using System;
using Silas.Service.Persons.DTO;

namespace Silas.Service.Person.Teste
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var persons = new Persons.Services.PersonServices();
            var result = persons.Create(new PersonDTO
            {
                Nome = "Silas",
                Telefone = "982199667",
                Nascimento = DateTime.Parse("1987-01-22")

            });
            var result3 = persons.Create(new PersonDTO
            {
                Nome = "Stan",
                Telefone = "999999999",
                Nascimento = DateTime.Parse("1981-08-03")

            });

            var result2 = persons.Get(result);


            Assert.IsTrue(result2.Nome == "Silas");
        }

        //[Test]

        //public void TestGetPerson()
        //{
        //    var getPerson = new Persons.Services.PersonServices();
        //    var result = getPerson.getPerson("silas");


        //}
    }
}