
using Data.Context;
using Silas.API.Models;
using System;
using Repository;
using Microsoft.AspNetCore.Authentication;
using Silas.Authentication.Models.Auth;

namespace Silas.API.Services
{
    public class AuthenticationServices
    {
        Authentication.Interfaces.IAuthenticationService authenticationService;
       
        DbSilasContext _users = new DbSilasContext();
        UsersRepository _usersRepository;

        public AuthenticationServices()
        {
            _usersRepository = new UsersRepository(_users);
            authenticationService = new Authentication.Services.AuthenticationService();
        }
        public IJWTAuth AuthenticationUser(AuthenticationModel user)
        {
            if (string.IsNullOrEmpty(user.Nome) || string.IsNullOrEmpty(user.Senha))
                throw new Exception("Usuario e senha não podem estar vazios");

            var _user = _usersRepository.GetByUserName(user.Nome).Result;
            if (_user == null)
                throw new Exception("Usuario não encontrado no banco de dados");
            if (user.Senha != _user.Password)
                throw new Exception("Usuário ou senha inválida");
            if (_user.PasswordStatus == 1)
                throw new Exception("Necessário troca de senha de usuário");


            var result = authenticationService.Authorization(_user.UserName,_user.Email, _user.Role, _user.Scope);


            return result;

        }

        public string RefreshToken(string token)
        {
            return authenticationService.RefreshToken(token).AccessToken;
        }
    }
}
