using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {

        private readonly IPatientRepository _patientRepository;

        public GetPatientDetailQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            if (patient is null)
            {
                throw new NotFoundException("Patient not found");
            }

            return patient.ToDTO();
        }
    }
}
