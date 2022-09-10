using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interface.Repository
{
    public interface IUsersRepository
    {
        Task Insert(UsersEntity user);
        public void Update(UsersEntity user);
        public void ChangeScopeAndRole(UsersEntity user);
        public Task Delete(UsersEntity user);
        Task<IQueryable<TData>> GetAll<TData>() where TData : Base;
        Task<TData> GetById<TData>(Guid Id) where TData : Base;



    }
}
