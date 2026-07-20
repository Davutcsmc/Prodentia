using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Commands.DeleteDentalOffice
{
    public class DeleteDentalOfficeCommandHandler : IRequestHandler<DeleteDentalOfficeCommand>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, 
            IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentalOfficeCommand request)
        {
            var dentalOffice = await _dentalOfficeRepository.GetByIdAsync(request.Id);
            if (dentalOffice == null)
            {
                throw new NotFoundException($"Dental office with ID {request.Id} not found.");
            }
            try
            {
                await _dentalOfficeRepository.DeleteAsync(dentalOffice);
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
