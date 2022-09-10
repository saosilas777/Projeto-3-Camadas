using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ITelefoneRepository : IBaseRepository<Telefones>
    {
        bool Add(Telefones telefone);
        bool AddRange(ICollection<Telefones> telefone);       
        
        void Delete(Telefones cliente);

        void Update(Telefones telefone);

        Task<IQueryable<TData>> GetAll<TData>() where TData : Base;
    }
}
