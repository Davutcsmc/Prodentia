using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Configurations
{
    internal class PatientConfig: IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.ComplexProperty(prop => prop.Email, action =>
            {
                action.Property(email => email.Value)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(254);
            });
                
        }
    }
}
