using Prodentia.Domain.Enums;
using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;

namespace Prodentia.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        
        public TimeInterval TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }


        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId,
            TimeInterval timeInterval)
        {           
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The {nameof(timeInterval.Start)} cannot be in the past");
            }

            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();
        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException($"The appointment cannot be canceled because it is not in the scheduled state");
            }

            if (Status == AppointmentStatus.Canceled)
            {
                throw new BusinessRuleException($"The appointment is already canceled");
            }

            Status = AppointmentStatus.Canceled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException($"The appointment cannot be completed because it is not in the scheduled state");
            }

            if (Status == AppointmentStatus.Completed)
            {
                throw new BusinessRuleException($"The appointment is already completed");
            }
            Status = AppointmentStatus.Completed;

        }
    }
}
