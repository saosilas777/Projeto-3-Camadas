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
    public class TelefonesRepository : BaseRepository<Telefones>, ITelefoneRepository
    {
        protected DbSilasContext _context = new DbSilasContext();


        public TelefonesRepository(DbSilasContext context) : base(context)
        {
            _context = context;

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public bool Add(Telefones telefone)
        {
            _context.Add(telefone);
            return true;
        }

        public async Task<HashSet<Telefones>> GetAll()
        {
            var x = (from l in _context.Telefone select l).AsEnumerable().ToHashSet();
            return x;
        }


        public bool AddRange(ICollection<Telefones> telefones)
        {
            _context.AddRange(telefones);
            return true;
        }

        public void Delete(Telefones telefone)
        {
            throw new NotImplementedException();
        }

        public void Update(Telefones telefone)
        {
            _context.Update(telefone);
            _context.SaveChanges();
        }
    }
}
