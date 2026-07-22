using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using Prodentia.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientListDTO>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetPatientsListQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await _patientRepository.GetFilteredPatientsAsync(request);
            var totalAmountOfRecords = await _patientRepository.GetTotalAmountOfRecords();

            var patientsDTO = patients.Select(p => p.ToDTO()).ToList();

            var paginatedDTO = new PaginatedDTO<PatientListDTO>
            {
                Items = patientsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedDTO;
        }
    }
}
