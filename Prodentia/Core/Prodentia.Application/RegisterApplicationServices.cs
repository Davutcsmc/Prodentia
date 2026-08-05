using Microsoft.Extensions.DependencyInjection;
using Prodentia.Application.Features.Appointments.Commands.CreateAppointment;
using Prodentia.Application.Features.Appointments.Queries.GetAppointmentDetail;
using Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using Prodentia.Application.Features.Dentists.Commands.CreateDentist;
using Prodentia.Application.Features.Dentists.Commands.DeleteDentist;
using Prodentia.Application.Features.Dentists.Commands.UpdateDentist;
using Prodentia.Application.Features.Dentists.Queries.GetDentistDetail;
using Prodentia.Application.Features.Dentists.Queries.GetDentistsList;
using Prodentia.Application.Features.Patients.Commands.CreateCommand;
using Prodentia.Application.Features.Patients.Commands.DeletePatient;
using Prodentia.Application.Features.Patients.Commands.UpdatePatient;
using Prodentia.Application.Features.Patients.Queries.GetPatientDetail;
using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Application.Utilities;
using Prodentia.Application.Utilities.Common;

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

            services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>, DeleteDentalOfficeCommandHandler>();

            services.AddScoped<IRequestHandler<CreatePatientCommand, Guid>, CreatePatientCommandHandler>();

            services.AddScoped<IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientListDTO>>,
                GetPatientsListQueryHandler>();

            services.AddScoped<IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>,
                GetPatientDetailQueryHandler>();

            services.AddScoped<IRequestHandler<UpdatePatientCommand>, UpdatePatientCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePatientCommand>, DeletePatientCommandHandler>();

            services.AddScoped<IRequestHandler<CreateDentistCommand, Guid>, CreateDentistCommandHandler>();

            services.AddScoped<IRequestHandler<GetDentistsListQuery, PaginatedDTO<DentistListDTO>>,
                GetDentistsListQueryHandler>();

            services.AddScoped<IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>,
                GetDentistDetailQueryHandler>();

            services.AddScoped<IRequestHandler<UpdateDentistCommand>, UpdateDentistCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteDentistCommand>, DeleteDentistCommandHandler>();

            services.AddScoped<IRequestHandler<CreateAppointmentCommand, Guid>, CreateAppointmentCommandHandler>();
            services.AddScoped<IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>, 
                GetAppointmentDetailQueryHandler>();
            services.AddScoped<IRequestHandler<GetAppointmentListQuery, List<AppointmentsListDTO>>,
                GetAppointmentListQueryHandler>();

            return services;
        }
    }
}
