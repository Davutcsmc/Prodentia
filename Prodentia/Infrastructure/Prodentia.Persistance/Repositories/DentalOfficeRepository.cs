using Prodentia.Application.Contracts.Repositories;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(ProdentiaDbContext context) : base(context)
        {
        }

    }
}
