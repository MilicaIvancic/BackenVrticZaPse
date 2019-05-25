using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder.Property(p => p.VaccineName).HasMaxLength(35).IsRequired();
            builder.HasIndex(p => p.VaccineName).IsUnique();

            builder.HasMany(p => p.VaccineHealthCards)
                .WithOne(pe => pe.Vaccine)
                .HasForeignKey(pe => pe.VaccineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
