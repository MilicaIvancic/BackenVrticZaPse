using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.Property(p => p.CertificateName).HasMaxLength(100).IsRequired();
            builder.HasIndex(p => p.CertificateName).IsUnique();

            builder.HasMany(p => p.CertificateEmployees)
               .WithOne(pe => pe.Certificate)
               .HasForeignKey(pe => pe.CertificateId)
               .OnDelete(DeleteBehavior.Restrict);

            // kada se obrise sertifikad obrisace se svi zapisi iz tabele sa svim zaposlenima
            //koji su imali taj sertifikat ali se nece brisati zaposleni?
        }
    }
}
