using Silas.Authentication.Interfaces;
using Silas.Authentication.Models.Auth;
using Silas.Authentication.Services;
using System.Security.Claims;

namespace AuthenticationTest
{
    public class UnitTest1
    {
        IAuthenticationService authenticationService;
        public UnitTest1()
        {

            authenticationService = new AuthenticationService();
        }

        [Fact]
        public void AuthToken()
        {


            var token = authenticationService.Authorization("Silas","silasdiasdev@gmail.com", 1, 1);
            Assert.NotNull(token);


        }

        [Fact]
        public void OpenToken()
        {
            var token = authenticationService.GetDataFromToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6IlNpbGFzIiwiUm9sZSI6IjEiLCJTY29wZSI6IjEiLCJDcmVhdGVkIjoiMTkvMDgvMjAyMiAwMToyMzozNCIsIlJlZnJlc2hUb2tlbiI6IjE5LzA4LzIwMjIgMDE6MjM6MzQiLCJuYmYiOjE2NjA4NzIyMTQsImV4cCI6MTY2MDg3NTgxNCwiaWF0IjoxNjYwODcyMjE0fQ.LAOpSs2m2OdP0d9IiuLSmJV6nQgBWwMi3DndfTKOIIQ");

        }

        

        [Fact]
        public void Refresh()
        {
            var token2 = authenticationService.Authorization("Silas","silasdiasdev@gmail.com", 2, 3, 0.3);
            var obj = authenticationService.GetDataFromToken(token2.AccessToken);

            var identity = new ClaimsIdentity();
            identity.AddClaims(new[]
            {
                new Claim("Created", token2.Created.ToString()),
                new Claim("RefreshToken", token2.RefreshToken.ToString()),
                new Claim("UserName", obj.Data.UserName.ToString()),
                new Claim("Scope", obj.Data.Scope),
                new Claim("Role", obj.Data.Role),
            });


            var token = authenticationService.RefreshToken(identity.Claims);

            Assert.NotNull(token);

        }

        [Fact]
        public void RefresByToken()
        {
            var token = authenticationService.RefreshToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6IlNpbGFzIiwiUm9sZSI6IjEiLCJTY29wZSI6IjEiLCJDcmVhdGVkIjoiMjAvMDgvMjAyMiAxMzozNTozNCIsIlJlZnJlc2hUb2tlbiI6IjIwLzA4LzIwMjIgMTM6MzU6MzQiLCJuYmYiOjE2NjEwMDI1MzQsImV4cCI6MTY2MTAwNjEzNCwiaWF0IjoxNjYxMDAyNTM0fQ.ciK8CwllzLWtKToDg63i77cni_OwPj9DcTHOj84Jqdg");

            Assert.NotNull(token);
        }
    }
}