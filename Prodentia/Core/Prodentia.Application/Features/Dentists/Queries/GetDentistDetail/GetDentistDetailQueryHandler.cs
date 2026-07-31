using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistDetail
{
    public class GetDentistDetailQueryHandler : IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>
    {
        IDentistRepository _dentistRepository;
        public GetDentistDetailQueryHandler(IDentistRepository repository)
        {
            _dentistRepository = repository;
        }

        public async Task<DentistDetailDTO> Handle(GetDentistDetailQuery request)
        {
            var dentist = await _dentistRepository.GetByIdAsync(request.Id);

            if (dentist is null)
            {
                // Handle the case when the dentist is not found
                throw new NotFoundException("Dentist not found");
            }

            return dentist.ToDTO();
        }
    }
}
