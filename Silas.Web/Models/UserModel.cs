namespace Silas.Web.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public bool Authorized { get; set; }
    }
}
