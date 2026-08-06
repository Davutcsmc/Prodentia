using Microsoft.Extensions.Configuration;
using Prodentia.Application.Notifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Prodentia.Infrastructure.Notifications
{
    public class EmailService : INotifications
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAppointmentNotification(AppointmentConfirmationDTO appointmentConfirmationDTO)
        {
            var subject = "Appointment Confirmation - Prodentia";
            var body = $"Dear {appointmentConfirmationDTO.Patient},\n\n" +
                       $"Your appointment with Dr. {appointmentConfirmationDTO.Dentist} at {appointmentConfirmationDTO.DentalOffice} " +
                       $"is confirmed for {appointmentConfirmationDTO.Date.ToString("f",new CultureInfo("tr-TR"))}.\n\n" +
                       $"Thank you for choosing Prodentia!\n\n" +
                       $"Best regards,\n" +
                       $"Prodentia Team";

            await SendEmailAsync(appointmentConfirmationDTO.Patient_Email, subject, body);
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var from = _configuration.GetValue<string>("EmailSettings:From");
            var password = _configuration.GetValue<string>("EmailSettings:Password");
            var host = _configuration.GetValue<string>("EmailSettings:Host");
            var port = _configuration.GetValue<int>("EmailSettings:Port");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, password);

            var message = new MailMessage(from!, to, subject, body);
            await smtpClient.SendMailAsync(message);
        }
    }
}
