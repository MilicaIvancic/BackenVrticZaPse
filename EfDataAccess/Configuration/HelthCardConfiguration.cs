using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class HelthCardConfiguration : IEntityTypeConfiguration<HealthCard>
    {
        public void Configure(EntityTypeBuilder<HealthCard> builder)
        {
            builder.Property(p => p.CardNumer).HasMaxLength(50).IsRequired();
            builder.HasOne(p => p.Dog).WithMany(u => u.HealthCards);

            builder.HasMany(p => p.HelthCardVaccines)
                .WithOne(pe => pe.HealthCard)
                .HasForeignKey(pe => pe.HealthCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
