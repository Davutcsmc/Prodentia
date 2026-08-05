using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentListQueryHandler : IRequestHandler<GetAppointmentListQuery, List<AppointmentsListDTO>>
    {
        private readonly IAppointmentRepository _repository;
        public GetAppointmentListQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<AppointmentsListDTO>> Handle(GetAppointmentListQuery request)
        {
            var appointments = await _repository.GetFiltered(request);
            var appointmentsDTO = appointments.Select(x => x.ToDTO()).ToList();
            return appointmentsDTO;
        }
    }
}
