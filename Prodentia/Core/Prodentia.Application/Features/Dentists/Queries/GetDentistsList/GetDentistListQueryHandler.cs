using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using Prodentia.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQueryHandler : IRequestHandler<GetDentistsListQuery, PaginatedDTO<DentistListDTO>>
    {
        private readonly IDentistRepository _dentistRepository;
        public GetDentistsListQueryHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public async Task<PaginatedDTO<DentistListDTO>> Handle(GetDentistsListQuery request)
        {
            var dentists = await _dentistRepository.GetFilteredDentistsAsync(request);
            var totalAmountOfRecords = await _dentistRepository.GetTotalAmountOfRecords();

            var dentistsDTO = dentists.Select(d => d.ToDTO()).ToList();

            var paginatedDTO = new PaginatedDTO<DentistListDTO>
            {
                Items = dentistsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedDTO;
        }
    }
}
