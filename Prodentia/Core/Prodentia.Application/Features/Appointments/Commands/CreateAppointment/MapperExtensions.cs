using Prodentia.Application.Notifications;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CreateAppointment
{
    internal static class MapperExtensions
    {
        internal static AppointmentConfirmationDTO ToDTO(this Appointment appointment)
        {
            return new AppointmentConfirmationDTO
            {
                Id = appointment.Id,
                Patient = appointment.Patient!.Name,
                Patient_Email = appointment.Patient!.Email.Value,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                Date = appointment.TimeInterval.Start
            };
        }
    }
}
