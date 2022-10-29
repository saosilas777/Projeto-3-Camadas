using System;

namespace Silas.Web.Models
{
    public class HistoricoContatoModel
    {
        public Guid ClienteID { get; set; }
        public DateTime Data { get; set; }
        public string? RegistroDeContato { get; set; }
    }
}
