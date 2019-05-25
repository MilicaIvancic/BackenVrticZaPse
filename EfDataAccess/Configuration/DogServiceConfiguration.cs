using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class DogServiceConfiguration : IEntityTypeConfiguration<DogService>
    {
        public void Configure(EntityTypeBuilder<DogService> builder)
        {
            builder.HasOne(p => p.Dog).WithMany(u => u.DogServices);
            builder.HasOne(p => p.Service).WithMany(u => u.ServiceDogs);
        }
    }
}
