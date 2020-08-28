using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class HealthCardVaccineConfiguration : IEntityTypeConfiguration<HealthCardVaccine>
    {
        public void Configure(EntityTypeBuilder<HealthCardVaccine> builder)
        {
            builder.HasOne(p => p.HealthCard).WithMany(u => u.HelthCardVaccines);
            builder.HasOne(p => p.Vaccine).WithMany(u => u.VaccineHealthCards);
            builder.Property(p => p.RecivedAt).IsRequired();
        }
    }
}
