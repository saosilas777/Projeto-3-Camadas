using Silas.Authentication.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Authentication.Models.Responses
{
    public class AuthorizationResponse
    {
        private bool _authorized;
        private string _accessToken;

        public AuthorizationResponse(IJWTAuth Auth)
        {

            this._authorized = Auth.Authorized;
            this.SetToken(Auth.AccessToken);

        }

        public void SetToken(string newToken)
        {
            this._accessToken = newToken;
        }

        public bool Authorized => this._authorized;
        public string AccessToken => this._accessToken;
    }
}
