using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Notifications;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly INotifications _notifications;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork, INotifications notifications) 
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }
        
        public async Task<Guid> Handle(CreateAppointmentCommand request)
        {
            var existOverlap = await _appointmentRepository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);

            if (existOverlap)
            {
                throw new CustomValidationException("The appointment overlaps with an existing appointment for the dentist.");
            }

            var timeInterval = new TimeInterval(request.StartDate, request.EndDate);
            var appointment = new Appointment(request.PatientId, 
                request.DentistId, 
                request.DentalOfficeId, 
                timeInterval);

            Guid? id = null;

            try
            {
                var result = await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.Commit();

                id = result.Id;
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }

            var appointment1 = await _appointmentRepository.GetByIdAsync(id.Value);
            var appointmentConfirmationDTO = appointment1!.ToDTO();
            await _notifications.SendAppointmentNotification(appointmentConfirmationDTO);

            return id.Value;
        }
    }
}
