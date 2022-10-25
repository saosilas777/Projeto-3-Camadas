using Data.Context;
using Domain.Entity;
using Repository;
using Silas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silas.API.Services
{
    public class ClienteServices
    {
        #region ATTRIBUTES

        private DbSilasContext _context;
        private CLienteRepository _clienteRepository;
        private TelefonesRepository _telefoneRepository;
        private EmailsRepository _emailsRepository;
        private HistoricoCompraRepository _compraRepository;
        private HistoricoClienteRepository _historicoRepository;
        #endregion



        #region CONSTRUCTOR

        public ClienteServices()
        {
            _context = new DbSilasContext();
            _clienteRepository = new CLienteRepository(_context);
            _telefoneRepository = new TelefonesRepository(_context);
            _emailsRepository = new EmailsRepository(_context);
            _compraRepository = new HistoricoCompraRepository(_context);
            _historicoRepository = new HistoricoClienteRepository(_context);

        }
        #endregion

        #region PUBLIC

        public string Create(ClienteModels cliente)
        {
            if (VerifyCliente(cliente.Codigo))
                throw new Exception("Cliente já possui cadastro!");
            Validate(cliente);

            Cliente _cliente = new Cliente { Codigo = cliente.Codigo, RazaoSocial = cliente.RazaoSocial, Bairro = cliente.Bairro, Cidade = cliente.Cidade, Estado = cliente.Estado, IsActive = true };
            var ClienteId = _clienteRepository.Add(_cliente);

            ICollection<Telefones> _telefones = new List<Telefones>();
            foreach (var telefone in cliente.Contato.Telefone)
            {
                _telefones.Add(new Telefones { ClienteId = ClienteId, Telefone = telefone.Telefone, IsActive = true });
            }


            ICollection<Emails> _emails = new List<Emails>();
            foreach (var email in cliente.Contato.Email)
            {
                _emails.Add(new Emails { ClienteId = ClienteId, Email = email.Email, IsActive = true });
            }


            var telefoneResult = _telefoneRepository.AddRange(_telefones);
            var emailResult = _emailsRepository.AddRange(_emails);
            if (telefoneResult && emailResult)
            {
                _context.SaveChanges();
            }
            return "Cliente cadastrado";

        }

        public string DisableTelefone(Guid id, bool isActive)
        {
            var _telefone = _telefoneRepository.GetAll().Result.Where(x => x.Id == id).FirstOrDefault();
            _telefone.IsActive = isActive;
            _telefoneRepository.Update(_telefone);
            if (_telefone.IsActive)
                return "Telefone habilitado";
            return "Telefone desabilitado";
        }
        public string DisableEmail(Guid id, bool isActive)
        {
            var _email = _emailsRepository.GetAll().Result.Where(x => x.Id == id).FirstOrDefault();
            _email.IsActive = isActive;
            _emailsRepository.Update(_email);
            if (_email.IsActive)
                return "Email habilitado";
            return "Email desabilitado";
        }


        public async Task<object> GetAll()
        {
            return await _clienteRepository.GetAll();
        }
        public async Task<object> GetByCode(int code)
        {
            return await _clienteRepository.GetByCode(code);
        }

        public string AddCompra(HistoricoCompraModel compra)
        {
            var cliente = _clienteRepository.GetAll().Result.Where(x => x.Id == compra.ClienteID).FirstOrDefault();
            HistoricoCompra _compra = new HistoricoCompra { ClienteId = cliente.Id, Data = compra.Data, Valor = compra.Valor, IsActive = true };
            _compraRepository.Add(_compra);
            
            return "Compra cadastrada";
            
            
        }
        public string AddRegistro(HistoricoClienteModel resgistro)
        {
            var cliente = _clienteRepository.GetAll().Result.Where(x => x.Id == resgistro.ClienteID).FirstOrDefault();
            HistoricoCliente _registro = new HistoricoCliente { ClienteId = cliente.Id, Data = DateTime.Now, RegistroDeContato = resgistro.RegistroDeContato, IsActive = true };
            _historicoRepository.Add(_registro);

            return "Registro cadastrado";


        }

        public string AddTelefone(string[] telefone, Guid id)
        {
            ICollection<Telefones> _telefones = new List<Telefones>();
            foreach (string numero in telefone)
            {
                _telefones.Add(new Telefones { ClienteId = id, Telefone = numero, IsActive = true });
            }

            _telefoneRepository.AddRange(_telefones);
            _telefoneRepository.SaveChanges();
            return "Numero(s) cadastrado";
        }


        #endregion

        #region PRIVATE

        private bool VerifyCliente(int codigo)
        {
            var entity = _clienteRepository.GetAll().Result.Where(x => x.Codigo == codigo).FirstOrDefault();

            if (entity == null)
                return false;
            return true;

        }
        private bool Validate(ClienteModels cliente)
        {
            if (string.IsNullOrEmpty(cliente.Codigo.ToString().Trim()))
                throw new Exception("O campo código não pode estar vazio");
            if (string.IsNullOrEmpty(cliente.RazaoSocial.Trim()))
                throw new Exception("O campo Razão Social não pode estar vazio");
            if (string.IsNullOrEmpty(cliente.Bairro.Trim()))
                throw new Exception("O campo Bairro não pode estar vazio");
            if (string.IsNullOrEmpty(cliente.Cidade.Trim()))
                throw new Exception("O campo Cidade não pode estar vazio");
            if (string.IsNullOrEmpty(cliente.Estado.Trim()))
                throw new Exception("O campo Estado não pode estar vazio");
            if (cliente.Codigo.ToString().Length < 5 || cliente.Codigo.ToString().Length > 5)
                throw new Exception("O campo código aceita somente 5 caractéres");
            return true;
        }


        #endregion

    }
}
