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
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                query = query.Where(p => p.Email.Value.Contains(filter.Email));
            }

            return await query
                .OrderBy(p => p.Name)
                .ApplyPagination(filter.PageNumber, filter.PageSize)
                .ToListAsync();
        }
    }
}
