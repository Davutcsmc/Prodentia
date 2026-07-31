using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistDetail
{
    public class GetDentistDetailQuery : IRequest<DentistDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
