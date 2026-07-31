using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Commands.UpdateDentist
{
    public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDentistCommandHandler(IDentistRepository dentistRepository, IUnitOfWork unitOfWork)
        {
            _dentistRepository = dentistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDentistCommand request)
        {
            var dentist = await _dentistRepository.GetByIdAsync(request.Id);
            if (dentist is null)
            {
                throw new NotFoundException($"Dentist with ID {request.Id} not found.");
            }

            dentist.UpdateName(request.Name);
            var email = new Email(request.Email);
            dentist.UpdateEmail(email);

            try
            {
                await _dentistRepository.UpdateAsync(dentist);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw new Exception($"An error occurred while updating the dentist: {ex.Message}", ex);
            }
        }
    }
}
