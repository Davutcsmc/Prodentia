using Microsoft.EntityFrameworkCore;
using Prodentia.Domain.Entities;
using Prodentia.Persistance.Configurations;

namespace Prodentia.Persistance
{
    public class ProdentiaDbContext : DbContext
    {
        public ProdentiaDbContext(DbContextOptions<ProdentiaDbContext> options)
            : base(options)
        {

        }

        protected ProdentiaDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalOfficeConfig).Assembly);
        }


        public DbSet<DentalOffice> DentalOffices { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
