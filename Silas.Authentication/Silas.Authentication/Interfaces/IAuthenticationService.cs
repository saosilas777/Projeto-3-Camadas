using Silas.Authentication.Models.Auth;
using Silas.Authentication.Models.Responses;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Silas.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        IJWTAuth Authorization(string userName,string email, int role, int scope, double expirationMinutes = 60);

        IJWTAuth RefreshToken(IEnumerable<Claim> claims);
        IJWTAuth RefreshToken(string token);

        string CreateToken(string username, string email, int role, int scope, string refreshToken, DateTime dateCreated, DateTime expiration);

        //TokenLinkConfigurationModel GetDataInToken(string token);

        ResponseModel<TokenLinkConfigurationModel> GetDataFromToken(string token);
    }
}
