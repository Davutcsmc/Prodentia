using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public GetAppointmentDetailQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);

            if (appointment is null)
            {
                throw new NotFoundException("Appointment not found");
            }

            return appointment.ToDTO();
        }
    }
}
