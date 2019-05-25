using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class MedicineMedicalReportConfiguration : IEntityTypeConfiguration<MedicineMedicalReport>
    {
        public void Configure(EntityTypeBuilder<MedicineMedicalReport> builder)
        {
            builder.HasKey(pc => new { pc.MedicalReportId, pc.MedicineId });
            builder.Property(u => u.StartDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
