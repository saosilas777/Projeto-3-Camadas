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
    public class UsersMap : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.PasswordStatus).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Scope).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.LastModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

        }
    }
}
