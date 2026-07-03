using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQuery: IRequest<DentalOfficeDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
