using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandHandler : IRequestHandler<CreateDentistCommand, Guid>
    {
        private readonly IDentistRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentistCommand request)
        {
            var email = new Email(request.Email);
            var dentist = new Dentist(request.Name, email);
            try
            {
                var result = await _repository.AddAsync(dentist);
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
