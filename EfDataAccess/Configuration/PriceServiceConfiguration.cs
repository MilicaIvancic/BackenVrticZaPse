using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class PriceServiceConfiguration : IEntityTypeConfiguration<PriceService>
    {
        public void Configure(EntityTypeBuilder<PriceService> builder)
        {
            builder.HasOne(p => p.Service).WithMany(s => s.PriceServices);
        }
    }
}
