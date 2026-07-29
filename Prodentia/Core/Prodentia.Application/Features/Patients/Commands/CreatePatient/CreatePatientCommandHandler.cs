using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Commands.CreateCommand
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePatientCommand request)
        {
            var email = new Email(request.Email);
            var patient = new Patient(request.Name, email);
            try
            {
                var result = await _repository.AddAsync(patient);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }            
        }
    }
}
