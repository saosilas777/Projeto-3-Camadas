using Data.Context;
using Domain.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        DbSilasContext _context;
        

        public UnitOfWork(DbSilasContext db)
        {
            _context = db;
        }
        public async Task<bool> Commit() => await _context.Commit();

        public async void Dispose() => _context.Dispose();

    }
}
