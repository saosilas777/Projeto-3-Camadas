using Data.Context;
using Domain.Entity.Util;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Util
{
    public class ScopesRepository
    {
        protected DbSilasContext _context;

        public ScopesRepository(DbSilasContext context)
        {
            _context = context;
        }

        public async Task Add(Scopes scopes)
        {
            _context.Add(scopes);
            _context.SaveChanges();
        }
        public async Task<HashSet<Scopes>> GetAll()
        {
            var x = (from l in _context.Scopes select l).AsEnumerable().ToHashSet();
            return x;
        }

    }
}
