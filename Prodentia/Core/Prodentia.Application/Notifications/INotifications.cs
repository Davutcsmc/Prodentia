using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Notifications
{
    public interface INotifications
    {
        Task SendAppointmentNotification(AppointmentConfirmationDTO appointmentConfirmationDTO);
    }
}
