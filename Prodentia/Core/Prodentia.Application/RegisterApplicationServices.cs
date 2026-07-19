using Microsoft.Extensions.DependencyInjection;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using Prodentia.Application.Utilities;

namespace Prodentia.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
            services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, 
                GetDentalOfficeDetailQueryHandler>();

            services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>, 
                GetDentalOfficesListQueryHandler>();

            services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>, UpdateDentalOfficeCommandHandler>();

            return services;
        }
    }
}
