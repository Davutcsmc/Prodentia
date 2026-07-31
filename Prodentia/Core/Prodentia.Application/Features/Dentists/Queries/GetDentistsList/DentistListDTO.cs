using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistsList
{
    public class DentistListDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
