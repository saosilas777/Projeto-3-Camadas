using Domain.Entity.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interface.Repository.Util
{
    public interface ILoggerRepository : IBaseRepository<Logger>
    {
        Task<HashSet<Logger>> GetAll();
        Task SetLogger(Logger logger);
    }
}
