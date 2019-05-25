using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class PackageServiceConfiguration : IEntityTypeConfiguration<PackageService>
    {
        public void Configure(EntityTypeBuilder<PackageService> builder)
        {
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasKey(pc => new { pc.PackageId, pc.ServiceId });
            
        }
    }
}
