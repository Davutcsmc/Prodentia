using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Configurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ComplexProperty(p => p.TimeInterval, b =>
            {
                b.Property(p => p.Start).HasColumnName("StartDate");
                b.Property(p => p.End).HasColumnName("EndDate");
            });
        }
    }
}
