using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EfDataAccess.Configuration
{
    public class DogChronichDiesaseConfiguration:IEntityTypeConfiguration<DogChronichDisease>
    {
        public void Configure(EntityTypeBuilder<DogChronichDisease> builder)
        {
            builder.HasKey(pc => new { pc.DogId, pc.ChronicDiseaseId });
            builder.Property(p => p.Therapy).HasMaxLength(100).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
