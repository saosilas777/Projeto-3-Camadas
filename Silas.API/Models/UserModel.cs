namespace Silas.API.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    public class UserModel
    {
        public string UserName { get; set; }
        
        /// <summary>
        /// Password must have (special 1 caracter !@#$%* - 1 Upper caracter and  1 number caracter)
        /// </summary>
        public string Password { get; set; }
        public int PasswordStatus { get; set; }
        public string Email { get; set; }
        public int Scope { get; set; }
        public int Role { get; set; }
       
    }
}
