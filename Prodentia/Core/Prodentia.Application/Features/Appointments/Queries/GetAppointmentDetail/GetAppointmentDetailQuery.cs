using Prodentia.Application.Utilities;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQuery : IRequest<AppointmentDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
