using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetFilteredPatientsAsync(PatientsFilterDTO filter);
    }
}
