using Domain.Entity;
using Domain.Interface.Configurations;
using Domain.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        IUnitOfWork UnitOfWork { get; }
        Guid Add(Cliente cliente);
        Task AddRange();
        void Update();
        void Delete(Cliente cliente);
        void UpdateRange();

        Task<IQueryable<TData>> GetAll<TData>() where TData : Base;

        Task<TData> GetById<TData>(Guid Id) where TData : Base;
    }
}
