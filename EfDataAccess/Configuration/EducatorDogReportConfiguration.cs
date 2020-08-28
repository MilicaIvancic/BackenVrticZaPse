using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfDataAccess.Configuration
{
    public class EducatorDogReporttConfiguration: IEntityTypeConfiguration<EducatorReport>
    {
        public void Configure(EntityTypeBuilder<EducatorReport> builder)
        {

        }
    }
}
