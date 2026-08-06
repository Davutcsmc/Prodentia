using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CancelAppointment
{
    public class CancelAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
