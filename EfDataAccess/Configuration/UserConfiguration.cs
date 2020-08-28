using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserSex)
            .HasConversion(x => x.ToString(),
                x => (Sex)Enum.Parse(typeof(Sex), x)).IsRequired();

            builder.Property(p => p.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            

            builder.HasOne(p => p.Role).WithMany(r => r.Users);

            builder.HasMany(p => p.Dogs).WithOne(d => d.User);
            builder.HasMany(p => p.Payments).WithOne(d => d.User);
            builder.HasMany(p => p.Payouts).WithOne(d => d.User);
            builder.HasMany(p => p.Addresses).WithOne(d => d.User);
            builder.HasMany(p => p.Phones).WithOne(d => d.User);

            builder.HasOne(p => p.Employe).WithOne(r => r.User);

        

            builder.HasMany(p => p.VeterinarianMedicalReports)
             .WithOne(pm => pm.Veterinarian)
             .HasForeignKey(pm => pm.VeterinarianId)
             .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
