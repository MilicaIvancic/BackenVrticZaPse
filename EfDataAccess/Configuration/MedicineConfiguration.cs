using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.Property(p => p.MedicineName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasMany(p => p.MedicineMedicalReports)
             .WithOne(pe => pe.Medicine)
             .HasForeignKey(pe => pe.MedicineId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
