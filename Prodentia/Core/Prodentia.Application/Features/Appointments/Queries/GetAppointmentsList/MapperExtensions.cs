using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList
{
    internal static class MapperExtensions
    {
        internal static AppointmentsListDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentsListDTO
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
