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

        public async Task<HashSet<Cliente>> GetByCode(int code)
        {

            var cliente = (from l in _db.Cliente where l.Codigo == code select l).AsEnumerable().ToHashSet();
            return cliente;

        }
        public async Task<HashSet<HistoricoCliente>> GetRegistro(Guid code)
        {
            var result = (from l in _db.HistoricoCliente where l.ClienteId == code select l).AsEnumerable().ToHashSet();
            return result;
        }
    }
}