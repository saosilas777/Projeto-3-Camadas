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
    public class CLienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        protected DbSilasContext _clienteContext = new DbSilasContext();
        public CLienteRepository(DbSilasContext clienteContext) : base(clienteContext)
        {
            _clienteContext = clienteContext;
        }
        public void SaveChanges()
        {
            _clienteContext.SaveChanges();
        }
        public Guid Add(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            return cliente.Id;


            //_clienteContext.SaveChanges();
        }

        public async Task<HashSet<Cliente>> GetAll()
        {
            var cliente = (from l in _db.Cliente select l).AsEnumerable().ToHashSet();
            return cliente;
        }

        public Task AddRange()
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente cliente)
        {
            _clienteContext.Remove(cliente);
            _clienteContext.SaveChanges();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void UpdateRange()
        {
            throw new NotImplementedException();
        }
    }




}

