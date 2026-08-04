using Prodentia.Domain.Enums;

namespace Prodentia.API.DTOs.Appointments
{
    public class CreateAppointmentDTO
    {
        public Guid DentistId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DentalOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
