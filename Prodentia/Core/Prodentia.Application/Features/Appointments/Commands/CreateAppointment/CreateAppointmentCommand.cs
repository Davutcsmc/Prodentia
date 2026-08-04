using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public Guid PatientId { get; set; }
        public Guid DentistId { get; set; }
        public Guid DentalOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
