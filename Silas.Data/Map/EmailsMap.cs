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
    public class EmailsMap : IEntityTypeConfiguration<Emails>
    {
        public void Configure(EntityTypeBuilder<Emails> builder)
        {
            builder.ToTable("Emails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(2147483647);
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}