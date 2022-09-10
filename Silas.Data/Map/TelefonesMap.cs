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
    public class TelefonesMap : IEntityTypeConfiguration<Telefones>
    {
        public void Configure(EntityTypeBuilder<Telefones> builder)
        {
            builder.ToTable("Telefones");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}