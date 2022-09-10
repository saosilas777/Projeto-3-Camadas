using Data.Context;
using Domain.Entity.Util;
using Repository.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTeste2
{
    public class ScopesTeste
    {
        DbSilasContext _context = new DbSilasContext();
        ScopesRepository _scope;
        RolesRepository _roles;

        public ScopesTeste()
        {
            _scope = new ScopesRepository(_context);
            _roles = new RolesRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var result = _scope.Add(new Scopes
            {
                
                Descripytion = "Comercial"

            });
            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void AddRoles()
        {
            var result = _roles.Add(new Roles
            {
                Descripytion = "Gerente"

            });
            Assert.True(result.IsCompleted);
        }




    }
}
