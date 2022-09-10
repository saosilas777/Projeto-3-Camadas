using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Map
{
    public class HistoricoClienteMap : IEntityTypeConfiguration<HistoricoCliente>
    {
        public void Configure(EntityTypeBuilder<HistoricoCliente> builder)
        {
            builder.ToTable("HistoricoCliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.RegistroDeContato);
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}