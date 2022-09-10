using System;

namespace Silas.API.Models
{
    public class HistoricoClienteModel
    {
        public Guid ClienteID { get; set; }
        public DateTime Data { get; set; }
        public string RegistroDeContato { get; set; }
    }
}
