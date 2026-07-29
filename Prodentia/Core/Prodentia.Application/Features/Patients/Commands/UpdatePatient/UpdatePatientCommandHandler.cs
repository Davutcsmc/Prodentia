using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePatientCommand request)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            if (patient == null)
            {
                throw new NotFoundException($"Patient with ID {request.Id} not found.");
            }
                        
            patient.UpdateName(request.Name);
            var email = new Email(request.Email);
            patient.UpdateEmail(email);

            try
            {
                await _patientRepository.UpdateAsync(patient);
                await _unitOfWork.Commit();
            }
            catch (Exception ex) 
            {
                await _unitOfWork.Rollback();
                throw new Exception($"An error occurred while updating the patient: {ex.Message}", ex);
            }
        }
    }
}
