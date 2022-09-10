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
    public class LoggerMap : IEntityTypeConfiguration<Logger>
    {
        public void Configure(EntityTypeBuilder<Logger> builder)
        {
            builder.ToTable("Logger");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ApplicationName).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2147483647).IsRequired();
            builder.Property(x => x.Server).IsRequired();
            builder.Property(x => x.Line).IsRequired();
            builder.Property(x => x.ApplicationVersion);
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.Exception).IsRequired(false);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.EventId).IsRequired();
            builder.Property(x => x.CallerMemberName).IsRequired(false);
            builder.Property(x => x.Stack).IsRequired(false);
            builder.Property(x => x.InnerException).IsRequired(false);
            builder.Property(x => x.ApplicationOwner).IsRequired(false);
            builder.Property(x => x.Ambient).IsRequired(false);



        }
    }
}
