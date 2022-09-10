using Data.Context;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace DataTeste2
{
    public class UsersTest
    {
        DbSilasContext _users = new DbSilasContext();
        UsersRepository _usersRepository;

        public UsersTest()
        {
            _usersRepository = new UsersRepository(_users);
        }

        [Fact]
        public void Add()
        {
            var result = _usersRepository.Insert(new UsersEntity
            {
                UserName = "Dias",
                Password = "102030",
                Scope = 1,
                Role = 1,
                CreateDate = new DateTime(2022, 07, 20),
                LastModifiedDate = DateTime.Now,
                IsActive = true,


            });
            Assert.True(result.IsCompleted);
        }

        [Fact]

        public void GetAll()
        {
            var get = _usersRepository.GetAll();
            Assert.True(get.IsCompleted);

        }

        [Fact]
        public void Remove()
        {
            var user = _usersRepository.GetAll().Result.Where(x => x.Id == Guid.Parse("AFD88B06-839F-49B4-FF00-08DA6DBD969B")).FirstOrDefault();
            _usersRepository.Delete(user);
            _users.SaveChanges();

        }

        [Fact]
        public async void Update()
        {
            var user = _usersRepository.GetAll().Result.Where(x => x.UserName == "Dias").FirstOrDefault();
            user.UserName = "Fernando";
            _users.SaveChanges();


        }

    }



}

