using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    class DogHeatConfiguration : IEntityTypeConfiguration<DogHeat>
    {
        public void Configure(EntityTypeBuilder<DogHeat> builder)
        {
            builder.HasOne(p => p.Dog).WithMany(u => u.DogHeats);
        }
    }
}
