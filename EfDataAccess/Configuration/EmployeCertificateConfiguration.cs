using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class EmployeCertificateConfiguration : IEntityTypeConfiguration<EmployeCertificate>
    {
        public void Configure(EntityTypeBuilder<EmployeCertificate> builder)
        {
            builder.HasKey(pc => new { pc.EmployeId, pc.CertificateId });
        }
    }
}
