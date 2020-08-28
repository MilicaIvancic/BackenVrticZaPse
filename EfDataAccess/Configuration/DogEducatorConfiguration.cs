using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class DogEducatorConfiguration : IEntityTypeConfiguration<DogEducator>
    {
        public void Configure(EntityTypeBuilder<DogEducator> builder)
        {
            builder.Property(p => p.IsActive).HasDefaultValue(0).IsRequired();
            builder.HasKey(pc => new { pc.DogId, pc.EducatorId });
            builder.HasOne(d => d.Employe).WithMany(e => e.EducatorDogs).HasForeignKey(d => d.EducatorId);
            builder.Property(u => u.StartDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
