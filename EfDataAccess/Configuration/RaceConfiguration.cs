using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasMany(p => p.Dogs).WithOne(p => p.Race);
        }
    }
}
