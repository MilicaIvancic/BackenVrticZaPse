using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(p => p.CityName).HasMaxLength(20).IsRequired();
            builder.HasIndex(p => p.CityName).IsUnique();

            builder.Property(p => p.ZipCode).HasMaxLength(6).IsRequired();
            builder.HasIndex(p => p.ZipCode).IsUnique();
            builder.Property(s => s.IsActive).HasDefaultValue(true);

            builder.HasMany(p => p.Addresses).WithOne(a => a.City);
        }
    }
}
