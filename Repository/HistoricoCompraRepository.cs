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
    public class HistoricoCompraRepository : BaseRepository<HistoricoCompra>, IHistoricoCompraRepository
    {
        protected DbSilasContext _context = new DbSilasContext();


        public HistoricoCompraRepository(DbSilasContext context) : base(context)
        {
            _context = context;

        }
        public bool Add(HistoricoCompra compra)
        {
            _context.Add(compra);
            _context.SaveChanges();
            return true;
        }
    }
}