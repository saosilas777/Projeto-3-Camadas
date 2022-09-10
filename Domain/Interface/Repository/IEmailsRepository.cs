using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEmailsRepository : IBaseRepository<Emails>
    {
        bool Add(Emails telefone);
        bool AddRange(ICollection<Emails> telefone);
        void Update(Emails email);
        void Delete(Emails cliente);


    }
}