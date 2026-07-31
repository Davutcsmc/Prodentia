using Microsoft.EntityFrameworkCore;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.Dentists.Queries.GetDentistsList;
using Prodentia.Domain.Entities;
using Prodentia.Persistance.Utilities;

namespace Prodentia.Persistance.Repositories
{
    public class DentistRepository : Repository<Dentist>, IDentistRepository
    {
        private readonly ProdentiaDbContext _context;
        public DentistRepository(ProdentiaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dentist>> GetFilteredDentistsAsync(DentistsFilterDTO filter)
        {
            var query = _context.Dentists.AsQueryable();

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
