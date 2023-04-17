using Newtonsoft.Json;
using Silas.Web.Helpers;
using Silas.Web.Models;
using Silas.Web.Models.ViewModels;

namespace Silas.Web.Services
{
    public class AuthService
    {
        public UserModel Authentication(LoginViewModel login)
        {
            UserModel userModel;

            var Json = JsonConvert.SerializeObject(login);
            //string url = "https://localhost:5001/Authentication";
            string url = "http://192.168.15.100:9999/Authentication";
            var content = HttpHelper.POST(url, Json).Content;

           

            if (!content.Contains("Usuário ou senha inválida"))
            {
                var _userModel = JsonConvert.DeserializeObject<UserModel>(content);
                userModel= new UserModel { UserName = login.Nome, AccessToken = _userModel.AccessToken, Authorized = _userModel.Authorized };
                return userModel;
            }
            return new UserModel();
        }
    }
}
