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
    public class HistoricoCompraMap : IEntityTypeConfiguration<HistoricoCompra>
    {
        public void Configure(EntityTypeBuilder<HistoricoCompra> builder)
        {
            builder.ToTable("HistoricoCompra");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}