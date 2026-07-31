using Prodentia.Application.Contracts.Repositories;
using Prodentia.Domain.Entities;

namespace Prodentia.Persistance.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(ProdentiaDbContext context) : base(context)
        {
        }

    }
}
