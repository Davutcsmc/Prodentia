using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class DentalOfficeDetailDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
