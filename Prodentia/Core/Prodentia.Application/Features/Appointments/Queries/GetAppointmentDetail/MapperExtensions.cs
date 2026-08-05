using Prodentia.Application.Features.Patients.Queries.GetPatientDetail;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    internal static class MapperExtensions
    {
        internal static AppointmentDetailDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentDetailDTO
            {
                Id = appointment.Id,
                Patient = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End,
                Status = appointment.Status.ToString() 
            };
        }
    }
}
