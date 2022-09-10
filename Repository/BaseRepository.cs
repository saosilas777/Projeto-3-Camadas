using Data.Context;
using Domain.Entity;
using Domain.Interface.Configurations;
using Domain.Interface.Repository;
using Domain.Interface.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected DbSilasContext _db;
        public BaseRepository(DbSilasContext db)
        {
            _db = db;
        }

        public IUnitOfWork UnitOfWork => new UnitOfWork.UnitOfWork(_db);

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default) => await _db.AddAsync(entity, cancellationToken);
        

        public async Task AddRange(TEntity entity, CancellationToken cancellationToken = default) => await _db.AddRangeAsync(entity, cancellationToken);
        

        public void Dispose()
        {
            GC.Collect();
        }

        public async Task<IQueryable<TData>> GetAll<TData>() where TData : Base
        {
            DbSet<TData> dbset = _db.Set<TData>();
            return await Task.FromResult(dbset.AsQueryable<TData>());
        }

        public async Task<TData> GetById<TData>(Guid Id) where TData : Base
        {
            DbSet<TData> dbset = _db.Set<TData>();
            return await dbset.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync() ?? throw (new Exception("Nenhuma informação encontrada"));
        }

        public void Update(TEntity entity) => _db.Update(entity);
        

        public void UpdateRange(HashSet<TEntity> entity, CancellationToken cancellationToken = default) => _db.UpdateRange(entity, cancellationToken);
        
        public async Task Delete(UsersEntity user) => _db.Remove(user);

        
    }
}
