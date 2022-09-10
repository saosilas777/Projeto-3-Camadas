using Data.Context;
using Domain.Entity;
using Domain.Entity.Util;
using Repository;
using Repository.Util;
using Silas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Silas.API.Services
{
    public class UserService
    {
        #region ATTRIBUTES

        private DbSilasContext _context;
        private ScopesRepository _scopesRepository;
        private RolesRepository _roleRepository;
        private UsersRepository _usersRepository;
        private SendEmail _emailrecovery;

        #endregion

        #region CONSTRUCTOR

        public UserService()
        {
            _context = new DbSilasContext();
            _scopesRepository = new ScopesRepository(_context);
            _roleRepository = new RolesRepository(_context);
            _usersRepository = new UsersRepository(_context);
            _emailrecovery = new SendEmail();
        }
        #endregion

        #region PUBLIC

        #region Create
        public string Create(UserModels user)
        {
            if (VerifyUser(user.UserName))
                throw new Exception("User already exists on DataBase");
            Validate(user);
            UsersEntity _user = new UsersEntity { UserName = user.UserName.ToUpper(), Password = user.Password, PasswordStatus = 0, Email = user.Email, Role = user.Role, Scope = user.Scope };
            _user.CreateDate = DateTime.Now;
            _user.LastModifiedDate = DateTime.Now;
            _usersRepository.Insert(_user);
            return "Usuario cadastrado";

        }
        #endregion

        #region Disable

        public async Task<object> Disable(Guid id, bool isActive)
        {
            var person = _usersRepository.GetAll().Result.Where(x => x.Id == id).FirstOrDefault();
            person.IsActive = isActive;
            _usersRepository.Update(person);
            return await Task.FromResult(true);
        }
        #endregion

        #region UpDate

        public bool UpDate(UserModels user)
        {
            if (!VerifyUser(user.UserName))
                throw new Exception("User not exists on database");
            var person = _usersRepository.GetAll().Result.Where(x => x.UserName == user.UserName).FirstOrDefault();
            //person.Password = user.Password - verificar se o pwd é valido e atualizar
            person.Email = user.Email;
            person.LastModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region Changing Password

        //Method to change a Password of user
        public bool ChangingPassword(ChangePasswordModels user)
        {
            if (!VerifyUser(user.UserName))
                throw new Exception("User not exists on database");
            var person = _usersRepository.GetAll().Result.Where(x => x.UserName == user.UserName).FirstOrDefault();
            if (user.Password != person.Password)
                throw new Exception("Current password is wrong");
            if (user.NewPassword.Length < 6)
                throw new Exception("Password length must have 6 caracters");
            if (PasswordValidation(user.NewPassword))
                throw new Exception("Password rules is not valid");

            person.Password = user.NewPassword;
            person.PasswordStatus = 0;

            person.LastModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region GetAll

        public async Task<object> GetAll()
        {
            return await _usersRepository.GetAll();
        }
        #endregion

        #region RecoveryPassword

        public bool RecoveryPassword(string userName)
        {
            if (!VerifyUser(userName))
                throw new Exception("User not exists on database");

            var randomPwd = RandonPassword();

            var person = GetPerson(userName);
            person.PasswordStatus = 1;
            person.Password = randomPwd;
            _context.SaveChanges();

            if (GetPerson(userName).Password != randomPwd)
                throw new Exception("not possible rec password in database");

            _emailrecovery.SendMail(userName, "Password recovery", person.Email, randomPwd);
            return true;
        }
        #endregion

        #region ChangeScopeAndRole

        //Method to change a Scope of user
        public bool ChangingScopeAndRole(ScopeAndRoleModels user)
        {
            if (!VerifyUser(user.UserName))
                throw new Exception("User not exists on database");
            var person = _usersRepository.GetAll().Result.Where(x => x.UserName == user.UserName).FirstOrDefault();
            if (!Scope(user.Scope))
                throw new Exception("Scope is not valid");
            if (!Role(user.Role))
                throw new Exception("Role is not valid");
            person.Scope = user.Scope;
            person.Role = user.Role;
            person.LastModifiedDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        #endregion

        #endregion

        #region PRIVATE
        private bool VerifyUser(string userName)
        {
            var entity = _usersRepository.GetAll().Result.Where(x => x.UserName == userName).FirstOrDefault();

            if (entity == null)
                return false;
            return true;

        }

        private bool VerifyEmail(string email)
        {
            var entity = _usersRepository.GetAll().Result.Where(x => x.Email == email).FirstOrDefault();

            if (entity.Email != email)
                return false;
            return true;

        }

        private bool VerifyPassword(string password)
        {
            var entity = _usersRepository.GetAll().Result.Where(x => x.Password == password).FirstOrDefault();

            if (entity.Password != password)
                return false;
            return true;


        }
        //Camada de negócio para criação 

        private UsersEntity GetPerson(string userName)
        {
            return _usersRepository.GetByUserName(userName).Result;
        }

        private string RandonPassword()
        {
            Random random = new Random();
            string pwd = "";
            for (int i = 0; i < 6; i++)
            {
                pwd += random.Next(0, 9).ToString();
            }
            return pwd;
        }

        #region Validates

        private bool Validate(UserModels user)
        {
            if (string.IsNullOrEmpty(user.UserName.Trim()))
                throw new Exception("Name field cannot be empty");
            if (string.IsNullOrEmpty(user.Password.Trim()))
                throw new Exception("Password field cannot be empty");
            if (user.Password.Length < 6)
                throw new Exception("Password length must have 6 caracters");
            if (!PasswordValidation(user.Password))
                throw new Exception("Password rules is not valid");
            if (!Scope(user.Scope))
                throw new Exception("Scope is not valid");
            if (!Role(user.Role))
                throw new Exception("Role is not valid");

            return true;
        }


        // refatorar verificação
        private bool PasswordValidation(string pwd)
        {
            var counter = 0;

            for (int i = 0; i <= 5; i++)
            {
                var x = pwd.Substring(i);
                var value = Encoding.ASCII.GetBytes(x);

                if (value[0] >= 65 && value[0] <= 90)
                {
                    counter++;
                }
                if (value[0] >= 35 && value[0] <= 38 || value[0] == 64)
                {
                    counter++;
                }
                if (value[0] >= 48 && value[0] <= 57)
                {
                    counter++;
                }

            }

            if (counter >= 3)
                return true;
            return false;
        }
        #endregion

        #region RoleScopeMethods

        private bool Scope(int scopes)
        {
            var scope = _scopesRepository.GetAll().Result.Where(x => x.Id == scopes).FirstOrDefault();
            if (scope != null)
                return true;
            return false;
        }
        private bool Role(int role)
        {
            var roles = _roleRepository.GetAll().Result.Where(x => x.Id == role).FirstOrDefault();
            if (roles != null)
                return true;
            return false;
        }
        #endregion

        #endregion
        


    }
}
