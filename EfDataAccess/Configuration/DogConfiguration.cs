using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EfDataAccess.Configuration
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Accepted).HasDefaultValue(0);
            builder.Property(p => p.DogDescription).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Chip).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Img).IsRequired();
            builder.Property(p => p.Alt).IsRequired();
            builder.Property(e => e.DogSex)
            .HasConversion(x => x.ToString(), 
                x => (Sex)Enum.Parse(typeof(Sex), x)).IsRequired();

            builder.HasOne(p => p.User).WithMany(u => u.Dogs);
            builder.HasOne(p => p.Race).WithMany(r => r.Dogs);

            builder.HasMany(p => p.HealthCards).WithOne(h => h.Dog);
            builder.HasMany(p => p.Toys).WithOne(t => t.Dog);
        
            builder.HasMany(p => p.DogHeats).WithOne(t => t.Dog);
            builder.HasOne(d => d.User).WithMany(u => u.Dogs).HasForeignKey(d => d.UserId);

            builder.HasMany(p => p.DogEducators)
                .WithOne(pe => pe.Dog)
                .HasForeignKey(pe => pe.DogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.DogServices)
             .WithOne(ps => ps.Dog)
             .HasForeignKey(ps => ps.DogId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.DogMedicalReports)
             .WithOne(pm => pm.Dog)
             .HasForeignKey(pm => pm.DogId)
             .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.DogChronichDiseases)
                .WithOne(pe => pe.Dog)
                .HasForeignKey(pe => pe.DogId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
