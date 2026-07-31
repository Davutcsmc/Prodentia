using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistsList   
{
    internal static class MapperExtensions
    {
        internal static DentistListDTO ToDTO(this Dentist dentist)
        {
            return new DentistListDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}
