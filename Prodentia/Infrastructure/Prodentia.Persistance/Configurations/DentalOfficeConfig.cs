using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prodentia.Domain.Entities;

namespace Prodentia.Persistance.Configurations
{
    internal class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(EntityTypeBuilder<DentalOffice> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
