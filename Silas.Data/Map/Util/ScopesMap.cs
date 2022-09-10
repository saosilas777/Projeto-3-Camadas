using Domain.Entity.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Map.Util
{
    public class ScopesMap : IEntityTypeConfiguration<Scopes>
    {

        public void Configure(EntityTypeBuilder<Scopes> builder)
        {
            builder.ToTable("Scopes");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripytion).IsRequired();
        }

    }

}