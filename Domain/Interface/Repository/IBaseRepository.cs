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
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRange(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        Task Delete(UsersEntity user);
        void UpdateRange(HashSet<TEntity> entity, CancellationToken cancellationToken = default);

        Task<IQueryable<TData>> GetAll<TData>()where TData : Base;

        Task<TData> GetById<TData>(Guid Id)where TData : Base;
    }
}
