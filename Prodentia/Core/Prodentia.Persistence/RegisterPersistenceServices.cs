using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Persistence.Repositories;
using Prodentia.Persistence.UnitsOfWork;

namespace Prodentia.Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProdentiaDbContext>(options =>
            {
                options.UseSqlServer("YourConnectionStringHere");
            });

            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }
    }
}
