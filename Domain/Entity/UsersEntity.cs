using Domain.Entity.Util;
using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UsersEntity : Base , IAggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PasswordStatus { get; set; }
        public string Email { get; set; }
        public int Scope { get; set; }
        public int Role { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
