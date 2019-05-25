using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Street).HasMaxLength(50).IsRequired();
            builder.Property(p => p.StreetNumber).HasMaxLength(5).IsRequired();

            builder.HasOne(p => p.User).WithMany(u => u.Addresses);
            builder.HasOne(p => p.City).WithMany(c => c.Addresses);

        }
    }
}
