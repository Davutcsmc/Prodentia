using Prodentia.Application.Contracts.Repositories;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistence.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(ProdentiaDbContext context) 
            : base(context) 
        {
            
        }
    }
}
