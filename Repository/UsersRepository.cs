using Data.Context;
using Domain.Entity;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsersRepository : BaseRepository<UsersEntity>, IUsersRepository
    {
        protected DbSilasContext _users = new DbSilasContext();
        
       


        public UsersRepository(DbSilasContext users) : base(users)
        {
            _users = users;
            
        }

        public void ChangeRole(UsersEntity user)
        {
            _users.Update(user);
            _users.SaveChanges();
        }

        public void ChangeScopeAndRole(UsersEntity user)
        {
            _users.Update(user);
            _users.SaveChanges();
        }

        //public void Delete(Users user)
        //{
        //    _users.Remove(user);
        //    _users.SaveChanges();
        //}

        public async Task<HashSet<UsersEntity>> GetAll()
        {
            var x = (from l in _db.Users select l).AsEnumerable().ToHashSet();
            return x;
        }

        public async Task<TData> GetById<TData>(Guid Id) where TData : Base
        {
            DbSet<TData> dbset = _db.Set<TData>();
            return await dbset.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync() ?? throw (new Exception("Nenhuma informação encontrada"));
        }

        public async Task<UsersEntity>? GetByUserName(string userName)
        {
            var user = _users.Users.FirstOrDefault(l => l.UserName == userName);
            return Task.FromResult(user).Result;
        }

        public async Task Insert(UsersEntity user)
        {
            _users.Add(user);
            _users.SaveChanges();
        }

        public async Task Update(UsersEntity user)
        {
         
            _users.Update(user);
            _users.SaveChanges();

        }


       

       

    }
}
