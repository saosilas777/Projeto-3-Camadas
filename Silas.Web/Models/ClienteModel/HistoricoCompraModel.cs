﻿using System;

namespace Silas.Web.Models
{
    public class HistoricoCompraModel
    {
        public Guid ClienteID { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }
}
