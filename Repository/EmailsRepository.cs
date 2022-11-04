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
    public class EmailsRepository : BaseRepository<Emails>, IEmailsRepository
    {
        protected DbSilasContext _context = new DbSilasContext();


        public EmailsRepository(DbSilasContext context) : base(context)
        {
            _context = context;

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public bool Add(Emails email)
        {
            _context.Add(email);
            return true;
        }

        public async Task<HashSet<Emails>> GetAll()
        {
            var x = (from l in _context.Email select l).AsEnumerable().ToHashSet();
            return x;
        }

        public bool AddRange(ICollection<Emails> email)
        {
            _context.AddRange(email);
            return true;
        }

        public void Delete(Emails email)
        {
            _context.Remove(email);
        }

        public void Update(Emails email)
        {
            _context.Update(email);
            _context.SaveChanges();
        }
    }
}
