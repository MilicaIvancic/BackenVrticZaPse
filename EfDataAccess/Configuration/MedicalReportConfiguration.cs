using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class MedicalReportConfiguration : IEntityTypeConfiguration<MedicalReport>
    {
        public void Configure(EntityTypeBuilder<MedicalReport> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.HasOne(p => p.Veterinarian).WithMany(u => u.VeterinarianMedicalReports);
            builder.HasOne(p => p.Dog).WithMany(u => u.DogMedicalReports);

            builder.HasMany(p => p.MedicalReportMedicines)
              .WithOne(pe => pe.MedicalReport)
              .HasForeignKey(pe => pe.MedicalReportId)
              .OnDelete(DeleteBehavior.Restrict);
            //proveriti oko brisanja izvestaja ako se izbrise jedan lek iz baze?

        }
    }
}
