using Data.Context;
using Domain.Entity.Util;
using Domain.Interface.Repository.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Util
{
    public class LoggerRepository : BaseRepository<Logger>, ILoggerRepository
    {
        public LoggerRepository(DbSilasContext db) : base(db)
        {
        }

        public async Task<HashSet<Logger>> GetAll()
        {
            var x = (from l in _db.Logger select l).AsEnumerable().ToHashSet();
            return x;
        }

        public async Task SetLogger(Logger logger)
        {
            _db.Logger.Add(logger);
            _db.SaveChanges();
        }
    }
}
