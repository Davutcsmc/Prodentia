using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommandHandler : IRequestHandler<DeleteDentistCommand>
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            _dentistRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentistCommand request)
        {
            var dentist = await _dentistRepository.GetByIdAsync(request.Id);
            if (dentist is null)
            {
                throw new NotFoundException($"Dentist with ID {request.Id} not found.");
            }
            try
            {
                await _dentistRepository.DeleteAsync(dentist);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
