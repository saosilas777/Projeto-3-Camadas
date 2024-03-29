﻿using Domain.Entity;
using System.Collections.Generic;

namespace Silas.API.Models
{
    public class ClienteModel 
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool IsActive { get; set; }
        public ContatoModel Contato { get; set; }
        public HistoricoClienteModel HistoricoCliente { get; set; }


    }
}
