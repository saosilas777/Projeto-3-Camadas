using System.Collections.Generic;

namespace Silas.API.Models
{
    public class HistoricoClienteModel
    {
        public ICollection<HistoricoContatoModel> Historico { get; set; }
        public ICollection<HistoricoCompraModel> Compra { get; set; }
    }
}
