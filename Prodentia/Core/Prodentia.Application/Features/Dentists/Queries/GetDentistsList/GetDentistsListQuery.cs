using Prodentia.Application.Utilities;
using Prodentia.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQuery: DentistsFilterDTO, IRequest<PaginatedDTO<DentistListDTO>>
    {

    }
}
