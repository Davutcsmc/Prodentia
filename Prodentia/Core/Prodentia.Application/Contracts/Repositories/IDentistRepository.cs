using Prodentia.Application.Features.Dentists.Queries.GetDentistsList;
using Prodentia.Domain.Entities;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IDentistRepository : IRepository<Dentist>
    {
        Task<IEnumerable<Dentist>> GetFilteredDentistsAsync(DentistsFilterDTO filter);
    }
}
