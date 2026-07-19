using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IDentalOfficeRepository : IRepository<DentalOffice>
    {
    }
}
