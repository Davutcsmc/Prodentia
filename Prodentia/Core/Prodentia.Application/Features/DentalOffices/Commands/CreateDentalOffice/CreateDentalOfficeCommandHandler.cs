using FluentValidation;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Entities;

namespace Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDentalOfficeCommandHandler(
            IDentalOfficeRepository dentalOfficeRepository,
            IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            DentalOffice dentalOffice = new DentalOffice(command.Name);
            try
            {
                var result = await _dentalOfficeRepository.AddAsync(dentalOffice);
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
