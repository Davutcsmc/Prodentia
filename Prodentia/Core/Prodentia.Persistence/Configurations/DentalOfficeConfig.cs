using Microsoft.EntityFrameworkCore;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistence.Configurations
{
    internal class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DentalOffice> builder)
        {
            builder.Property(prop => prop.Name)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
