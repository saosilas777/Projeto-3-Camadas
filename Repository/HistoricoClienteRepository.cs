using Data.Context;
using Domain.Entity;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HistoricoClienteRepository : BaseRepository<HistoricoCliente>, IHistoricoClienteRepository
    {
        protected DbSilasContext _context = new DbSilasContext();


        public HistoricoClienteRepository(DbSilasContext context) : base(context)
        {
            _context = context;

        }
        public bool Add(HistoricoCliente historico)
        {
            _context.Add(historico);
            _context.SaveChanges();
            return true;
        }
    }
}