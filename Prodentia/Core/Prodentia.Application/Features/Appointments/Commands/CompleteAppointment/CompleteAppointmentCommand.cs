using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
