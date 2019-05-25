using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    class EducatorReportConfiguration : IEntityTypeConfiguration<EducetorReport>
    {
        public void Configure(EntityTypeBuilder<EducetorReport> builder)
        {
            builder.Property(p => p.DescriptionText).HasMaxLength(300).IsRequired();
            builder.HasOne(p => p.DogEducator).WithMany(u => u.EducetorReports);
        }
    }
}
