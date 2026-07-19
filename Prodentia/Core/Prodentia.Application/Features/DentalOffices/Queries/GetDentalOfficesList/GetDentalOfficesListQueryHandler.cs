using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler : 
        IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        public GetDentalOfficesListQueryHandler(IDentalOfficeRepository dentalOfficeRepository)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
        }
        public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
        {
            var dentalOffices = await _dentalOfficeRepository.GetAllAsync();
            var dentalOfficesListDto = dentalOffices.Select(d => d.ToDTO()).ToList();

            return dentalOfficesListDto;
        }
    }
}
