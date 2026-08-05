using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class AppointmentsFilterDTO
    {
        public Guid? PatientId { get; set; }
        public Guid? DentistId { get; set; }
        public Guid? DentalOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
    }
}
