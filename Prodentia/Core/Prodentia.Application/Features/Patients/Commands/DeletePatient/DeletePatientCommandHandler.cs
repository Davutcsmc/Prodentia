using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;

namespace Prodentia.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientCommandHandler(IPatientRepository patientRepository,
            IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(DeletePatientCommand request)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            if (patient is null)
            {
                throw new NotFoundException($"Patient with ID {request.Id} not found.");
            }
            try
            {
                await _patientRepository.DeleteAsync(patient);
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
