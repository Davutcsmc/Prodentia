using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistsList
{
    public class DentistsFilterDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
