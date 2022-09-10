using Data.Context;
using Domain.Entity.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Util
{
    public class RolesRepository
    {
        protected DbSilasContext _context;

        public RolesRepository(DbSilasContext context)
        {
            _context = context;
        }

        public async Task Add(Roles roles)
        {
            _context.Add(roles);
            _context.SaveChanges();
        }
        public async Task<HashSet<Roles>> GetAll()
        {
            var x = (from l in _context.Roles select l).AsEnumerable().ToHashSet();
            return x;
        }

    }
}
