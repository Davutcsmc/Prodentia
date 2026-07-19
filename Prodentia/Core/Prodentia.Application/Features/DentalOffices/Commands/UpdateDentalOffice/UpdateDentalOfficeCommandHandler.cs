using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandHandler : IRequestHandler<UpdateDentalOfficeCommand>
    {

        private readonly IDentalOfficeRepository _dentalOfficeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository,
            IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDentalOfficeCommand request)
        {
            try
            {
                var dentalOffice = await _dentalOfficeRepository.GetByIdAsync(request.Id);

                if (dentalOffice is null)
                {
                    throw new NotFoundException($"Dental office with ID {request.Id} not found.");
                }

                dentalOffice.UpdateName(request.Name);

                await _dentalOfficeRepository.UpdateAsync(dentalOffice);
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
