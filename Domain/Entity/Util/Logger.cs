using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Util
{
    public class Logger : Base, IAggregateRoot
    {
        public long EventId { get; set; }
        public DateTime DateTime { get; set; }
        public int Type { get; set; }
        public string Server { get; set; }
        public string Description { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string Ambient { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string Stack { get; set; }
        public int Line { get; set; }
        public string CallerMemberName { get; set; }
        public string ApplicationOwner { get; set; }
    }
}
