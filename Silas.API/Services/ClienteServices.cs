using Data.Context;
using Domain.Entity;
using Microsoft.Win32;
using Repository;
using Silas.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public string Cadastro(ClienteModel cliente)
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

        public string Remove(int codigo)
        {
                       
            var ClienteId = _clienteRepository.GetAll().Result.Where(x => x.Codigo == codigo).FirstOrDefault();


            var tel = _telefoneRepository.GetAll().Result.Where(x => x.ClienteId == ClienteId.Id).ToList();
            foreach (var telefone in tel)
            {
               _telefoneRepository.Delete(telefone);
            }
            var mail = _emailsRepository.GetAll().Result.Where(x => x.ClienteId == ClienteId.Id).ToList();
            foreach (var email in mail)
            {
                _emailsRepository.Delete(email);
            }

            _clienteRepository.Delete(ClienteId);
                _context.SaveChanges();
            
            return "Cliente deletado";

        }


        public string Atualizar(ClienteModel cliente)
        {
            var _cliente = _clienteRepository.GetAll().Result.Where(x => x.Codigo == cliente.Codigo).FirstOrDefault();
            var _tel = _telefoneRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id).ToList();
            var _mail = _emailsRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id).ToList();

            _cliente.RazaoSocial = cliente.RazaoSocial;
            _cliente.Bairro = cliente.Bairro;
            _cliente.Cidade = cliente.Cidade;
            _cliente.Estado = cliente.Estado;

            List<Telefones> tels = new List<Telefones>();

            foreach (var x in cliente.Contato.Telefone)
            {
                tels.Add(new Telefones { Telefone = x.Telefone });
            }


            for (int i = 0; i < tels.Count; i++)
            {
                if (tels[i].Telefone == null)
                {
                    _tel[i].Telefone = "";
                }
                else
                {
                    _tel[i].Telefone = tels[i].Telefone;
                }

            }

            List<Emails> emails = new List<Emails>();

            foreach (var x in cliente.Contato.Email)
            {
                emails.Add(new Emails { Email = x.Email });
            }

            for (int i = 0; i < emails.Count; i++)
            {
                if (emails[i].Email == null)
                {
                    _mail[i].Email = "";
                }
                else
                {
                    _mail[i].Email = emails[i].Email;
                }

            }

            _context.SaveChanges();
            return "Cliente Atualizado";

        }

        public string DisableTelefone(int codigo, bool isActive)
        {
            var _cliente = _clienteRepository.GetByCode(codigo).Result.FirstOrDefault();
            var _telefone = _telefoneRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id).FirstOrDefault();
            _telefone.IsActive = isActive;
            _telefoneRepository.Update(_telefone);
            if (_telefone.IsActive)
                return "Telefone habilitado";
            return "Telefone desabilitado";
        }
        public string DisableEmail(int codigo, bool isActive)
        {
            var _cliente = _clienteRepository.GetByCode(codigo).Result.FirstOrDefault();
            var _email = _emailsRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id).FirstOrDefault();
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
            var _cliente = _clienteRepository.GetByCode(code).Result.FirstOrDefault();
            ICollection<TelefonesModel> tels = new List<TelefonesModel>();
            ICollection<EmailsModel> emails = new List<EmailsModel>();
            ICollection<HistoricoContatoModel> registrosContato = new List<HistoricoContatoModel>();


            var telefones = _telefoneRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id);
            var mails = _emailsRepository.GetAll().Result.Where(x => x.ClienteId == _cliente.Id);
            var reg = _historicoRepository.GetRegistro(_cliente.Id).Result.Where(x => x.ClienteId == _cliente.Id);

            foreach (var tel in telefones)
            {
                tels.Add(new TelefonesModel { Telefone = tel.Telefone, IsActive = true });

            }

            foreach (var mail in mails)
            {
                emails.Add(new EmailsModel { Email = mail.Email, IsActive = true });

            }


            foreach (var x in reg)
            {
                registrosContato.Add(new HistoricoContatoModel { ClienteID = x.ClienteId, Data = x.Data, RegistroDeContato = x.RegistroDeContato });

            }


            var clienteModel = new ClienteModel
            {
                Bairro = _cliente.Bairro,
                Cidade = _cliente.Cidade,
                Codigo = _cliente.Codigo,
                Estado = _cliente.Estado,
                RazaoSocial = _cliente.RazaoSocial,
                IsActive = _cliente.IsActive,
                Contato = new ContatoModel
                {
                    Email = emails,
                    Telefone = tels,
                },
                HistoricoCliente = new HistoricoClienteModel
                {
                    Historico = registrosContato,

                }


            };

            return clienteModel;
        }
        public string AddCompra(HistoricoCompraModel compra, int codigo)
        {
            var cliente = _clienteRepository.GetAll().Result.Where(x => x.Codigo == codigo).FirstOrDefault();
            HistoricoCompra _compra = new HistoricoCompra { ClienteId = cliente.Id, Data = compra.Data, Valor = compra.Valor, IsActive = true };
            _compraRepository.Add(_compra);

            return "Compra cadastrada";


        }
        public string AddRegistro(HistoricoContatoModel resgistro, int codigo)
        {
            var cliente = _clienteRepository.GetAll().Result.Where(x => x.Codigo == codigo).FirstOrDefault();
            HistoricoCliente _registro = new HistoricoCliente { ClienteId = cliente.Id, Data = DateTime.Now, RegistroDeContato = resgistro.RegistroDeContato, IsActive = true };
            _historicoRepository.Add(_registro);

            return "Registro cadastrado";


        }

        public string AddTelefone(string[] telefone, int codigo)
        {
            var _cliente = _clienteRepository.GetByCode(codigo).Result.FirstOrDefault();
            ICollection<Telefones> _telefones = new List<Telefones>();
            foreach (string numero in telefone)
            {
                _telefones.Add(new Telefones { ClienteId = _cliente.Id, Telefone = numero, IsActive = true });
            }

            _telefoneRepository.AddRange(_telefones);
            _telefoneRepository.SaveChanges();
            return "Numero(s) cadastrado";
        }
        public string AddEmail(string[] email, int codigo)
        {
            var _cliente = _clienteRepository.GetByCode(codigo).Result.FirstOrDefault();
            ICollection<Emails> _email = new List<Emails>();
            foreach (string mail in email)
            {
                _email.Add(new Emails { ClienteId = _cliente.Id, Email = mail, IsActive = true });
            }

            _emailsRepository.AddRange(_email);
            _emailsRepository.SaveChanges();
            return "Email(s) cadastrado";
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
        private bool Validate(ClienteModel cliente)
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
