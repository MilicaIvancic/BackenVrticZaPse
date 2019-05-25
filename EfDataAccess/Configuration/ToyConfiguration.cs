using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class ToyConfiguration : IEntityTypeConfiguration<Toy>
    {
        public void Configure(EntityTypeBuilder<Toy> builder)
        {
            builder.Property(p => p.ToyName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.ToyDescription).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Dog).WithMany(p => p.Toys);

        }
    }
}
