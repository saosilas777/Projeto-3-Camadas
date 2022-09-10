using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Authentication.Models.Auth
{
    
    public interface IJWTAuth
    {
        string UserName { get; set; }
       
        bool Authorized { get; set; }
        /// <summary>
        /// Token de autenticação
        /// </summary>
        string AccessToken { get; }

        DateTime Created { get; }

        DateTime Expiration { get; }

        string RefreshToken { get; }

        IJWTAuth Refresh(string newAccessToken);

        IJWTAuth Create(string token);
    }
}
