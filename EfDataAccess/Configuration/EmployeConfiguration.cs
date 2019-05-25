using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Alt).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastFinishedEducation).HasMaxLength(50).IsRequired();

            builder.HasOne(p => p.User).WithOne(u => u.Employe);
        }
    }
}
