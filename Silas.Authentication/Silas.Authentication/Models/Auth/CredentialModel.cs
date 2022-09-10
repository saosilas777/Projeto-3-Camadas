using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Authentication.Models.Auth
{
    public class CredentialModel : IJWTAuth
    {
        private string _acessToken;
        private DateTime _created;
        private DateTime _expiration;
        private string _refreshToken;
        private readonly double _expirationIncrementeMinutes;
        private readonly double _maxExpirationIncrementMinutes;

        public CredentialModel(double expirationIncrementMinutes, double maxExpirationMinutes, string refreshedToken = null, DateTime? dateTimeCreated = null)
        {
            this._expirationIncrementeMinutes = expirationIncrementMinutes;
            this._maxExpirationIncrementMinutes = maxExpirationMinutes;

            if (!dateTimeCreated.HasValue)
            {
                this._created = DateTime.UtcNow;
                this._expiration = this.Created.AddMinutes(_expirationIncrementeMinutes);
            }
            else
            {
                this._created = dateTimeCreated.Value;
                this._expiration = DateTime.UtcNow.AddMinutes(this._expirationIncrementeMinutes);
            }
            if (!string.IsNullOrEmpty(refreshedToken))
            {
                this._refreshToken = refreshedToken;
            }
            else
            {
                this._refreshToken = (this.Created.ToString());
            }

            this.Authorized = false;
        }

        public CredentialModel()
        {
            this.Authorized = false;
            this._created = DateTime.UtcNow;
        }

        public bool Authorized { get; set; }
        public string AccessToken => this._acessToken;
        public DateTime Created => this._created;
        public DateTime Expiration => this._expiration;
        public string RefreshToken => this._refreshToken;
        public string UserName { get ; set; }
        public int Role { get; set; }
        public int Scope { get; set; }
        public IJWTAuth Create(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return this;

            this._acessToken = token;
            this.Authorized = true;

            return this;
        }

        public IJWTAuth Refresh(string newAccessToken)
        {
            if (this.RefreshToken != this.Created.ToString() || string.IsNullOrWhiteSpace(newAccessToken))
                return this;

            if (DateTime.UtcNow > this._created.AddMinutes(this._maxExpirationIncrementMinutes))
                return this;

            this.Authorized = true;
            this._expiration = DateTime.UtcNow.AddMinutes(this._expirationIncrementeMinutes);
            this._acessToken = newAccessToken;

            return this;
        }
    }
}
