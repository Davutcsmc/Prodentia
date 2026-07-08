using Microsoft.EntityFrameworkCore;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistence
{
    public class ProdentiaDbContext : DbContext
    {
        public ProdentiaDbContext(DbContextOptions<ProdentiaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdentiaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected ProdentiaDbContext() { }

        public DbSet<DentalOffice> DentalOffices { get; set; }
    }
}
