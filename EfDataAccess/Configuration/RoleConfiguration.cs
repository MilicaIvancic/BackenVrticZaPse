using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.RoleName).HasMaxLength(20).IsRequired();
            builder.HasIndex(p => p.RoleName).IsUnique();

            builder.HasMany(p => p.Users).WithOne(u => u.Role);
        }
    }
}
