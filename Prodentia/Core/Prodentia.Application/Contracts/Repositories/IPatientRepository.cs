using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Domain.Entities;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetFilteredPatientsAsync(PatientsFilterDTO filter);
    }
}
