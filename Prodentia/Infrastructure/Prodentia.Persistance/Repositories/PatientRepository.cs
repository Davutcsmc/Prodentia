using Microsoft.EntityFrameworkCore;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Domain.Entities;
using Prodentia.Persistance.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ProdentiaDbContext _context;
        public PatientRepository(ProdentiaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetFilteredPatientsAsync(PatientsFilterDTO filter)
        {
            return await _context
                .Patients
                .OrderBy(p => p.Name)
                .ApplyPagination(filter.PageNumber, filter.PageSize)
                .ToListAsync();
        }
    }
}
