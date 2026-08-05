using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentListQuery : AppointmentsFilterDTO, IRequest<List<AppointmentsListDTO>>
    {

    }
}
