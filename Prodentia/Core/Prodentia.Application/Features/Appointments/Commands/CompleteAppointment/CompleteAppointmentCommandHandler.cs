using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CompleteAppointmentCommand request)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException("The appointment was not found.");
            }

            appointment.Complete();
            
            try
            {
                await _appointmentRepository.UpdateAsync(appointment);
                await _unitOfWork.Commit();
            }
            catch (Exception ex) 
            {
                await _unitOfWork.Rollback();
                throw;
            }

            
        }
    }
}
