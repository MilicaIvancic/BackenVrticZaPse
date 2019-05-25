using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class ChronicDiseaseConfiguration : IEntityTypeConfiguration<ChronicDisease>
    {
        public void Configure(EntityTypeBuilder<ChronicDisease> builder)
        {
            builder.Property(p => p.NameChronicDisease).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Therapy).HasMaxLength(50).IsRequired();

            builder.HasOne(p => p.Dog).WithMany(u => u.ChronicDiseases);
        }
    }
}
