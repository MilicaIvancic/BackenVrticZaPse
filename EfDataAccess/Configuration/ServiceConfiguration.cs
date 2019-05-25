using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(p => p.ServiceName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasMany(p => p.ServiceDogs)
             .WithOne(ps => ps.Service)
             .HasForeignKey(ps => ps.DogId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PackageServices)
          .WithOne(ps => ps.Package)
          .HasForeignKey(ps => ps.PackageId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ServicePackages)
          .WithOne(ps => ps.Service)
          .HasForeignKey(ps => ps.ServiceId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PriceServices).WithOne(h => h.Service);



          

           
        }
    }
}
