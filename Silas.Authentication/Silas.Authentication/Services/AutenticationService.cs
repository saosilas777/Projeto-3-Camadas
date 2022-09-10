using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Silas.Authentication.Interfaces;
using Silas.Authentication.Models.Auth;
using Silas.Authentication.Models.Login;
using Silas.Authentication.Models.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Silas.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {


        private double _expirationMinutes;
        private readonly double _maxExpirationTimeMinutes;

        public AuthenticationService()
        {

            this._expirationMinutes = 60;
            this._maxExpirationTimeMinutes = 120;
        }

        public IJWTAuth Authorization(string userName,string email, int role, int scope, double expirationMinutes = 60)
        {
            try
            {
                this._expirationMinutes = expirationMinutes;



                IJWTAuth credentialModel = new CredentialModel(this._expirationMinutes, this._maxExpirationTimeMinutes);
                string token = this.CreateToken(userName,email, role, scope, credentialModel.RefreshToken, credentialModel.Created, credentialModel.Expiration);
                credentialModel.Create(token);
                return credentialModel;

            }
            catch (Exception ex)
            {
                //_logger.AddError($"Error to try get authorization of {userName}. Error: {ex.Message}", ex);
                throw ex;
                //return new CredentialModel();

            }
        }

        public string CreateToken(string username, string email, int role, int scope, string refreshToken, DateTime dateCreated, DateTime expiration)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("f35186d7-9ade-4fc1-91c0-e91a65ee758c");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserName", username),
                    new Claim("Email", email),
                    new Claim("Role", role.ToString()),
                    new Claim("Scope", scope.ToString()),
                    new Claim("Created", dateCreated.ToString()),
                    new Claim("RefreshToken", refreshToken),
                }),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private TokenLinkConfigurationModel GetDataInToken(string token)
        {
            if (!TokenIsValid(token))
                throw new Exception("Token is not valid.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            TokenLinkConfigurationModel tokenLinkConfigurationModel = new TokenLinkConfigurationModel
            {
                Role = securityToken.Claims.First(x => x.Type == "Role").Value,
                Scope = securityToken.Claims.First(x => x.Type == "Scope").Value,
                UserName = securityToken.Claims.First(x => x.Type == "UserName").Value,
                Email = securityToken.Claims.First(x => x.Type == "Email").Value,
                RefreshToken = securityToken.Claims.First(x => x.Type == "RefreshToken").Value,
                Created = securityToken.Claims.First(x => x.Type == "Created").Value,

            };

            return tokenLinkConfigurationModel;
        }

        public ResponseModel<TokenLinkConfigurationModel> GetDataFromToken(string token)
        {
            ResponseModel<TokenLinkConfigurationModel> result = new ResponseModel<TokenLinkConfigurationModel>();
            try
            {
                var _token = GetDataInToken(token);
                result.AddData(_token);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }

        public IJWTAuth RefreshToken(IEnumerable<Claim> claims)
        {
            DateTime.TryParse(claims.Where(a => a.Type == "Created").FirstOrDefault().Value, out var dateTimeCreated);
            string refreshToken = claims.Where(a => a.Type == "RefreshToken").FirstOrDefault().Value;
            string userName = claims.Where(a => a.Type == "UserName").FirstOrDefault().Value;
            string email = claims.Where(a => a.Type == "Email").FirstOrDefault().Value;
            int scope = int.Parse(claims.Where(a => a.Type == "Scope").FirstOrDefault().Value);
            int role = int.Parse(claims.Where(a => a.Type == "Role").FirstOrDefault().Value);

            IJWTAuth credentialModel = new CredentialModel(this._expirationMinutes, this._maxExpirationTimeMinutes, refreshToken, dateTimeCreated);
            string token = this.CreateToken(userName,email, role, scope, credentialModel.RefreshToken, credentialModel.Created, credentialModel.Expiration);
            credentialModel.Refresh(token);

            return credentialModel;

        }

        public IJWTAuth RefreshToken(string _token)
        {

            var tokenlink = GetDataInToken(_token);

            IJWTAuth credentialModel = new CredentialModel(this._expirationMinutes, this._maxExpirationTimeMinutes, tokenlink.RefreshToken, DateTime.Parse(tokenlink.Created));
            string token = this.CreateToken(tokenlink.UserName,tokenlink.Email, int.Parse(tokenlink.Role), int.Parse(tokenlink.Scope), credentialModel.RefreshToken, credentialModel.Created, credentialModel.Expiration);
            credentialModel.Refresh(token);

            return credentialModel;

        }

        private bool TokenIsValid(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("f35186d7-9ade-4fc1-91c0-e91a65ee758c"));

            var handler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValid = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };

                SecurityToken validateToken;
                handler.ValidateToken(token, tokenValid, out validateToken);
            }
            catch
            {
                return false;
            }

            return true;
        }


    }
}
