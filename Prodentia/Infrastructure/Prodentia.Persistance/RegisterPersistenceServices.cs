using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Persistance.Repositories;
using Prodentia.Persistance.UnitsOfWork;

namespace Prodentia.Persistance
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProdentiaDbContext>(options =>
                options.UseSqlServer("name=ProdentiaConnectionString"));

            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDentistRepository, DentistRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }
    }
}
