using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQueryHandler : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;

        public GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository dentalOfficeRepository)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
        }

        public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
        {
            var dentalOffice = await _dentalOfficeRepository.GetByIdAsync(request.Id);
            if (dentalOffice == null)
            {
                throw new NotFoundException($"Dental office with ID {request.Id} not found.");
            }

            return dentalOffice.ToDTO();
        }
    }
}
