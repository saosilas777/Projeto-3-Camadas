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
    public class RolesMap : IEntityTypeConfiguration<Roles>
    {

        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripytion).IsRequired();
        }

    }

}

