using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Queries.GetDentistDetail
{
    internal static class MapperExtensions
    {
        public static DentistDetailDTO ToDTO(this Dentist dentist)
        {
            return new DentistDetailDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}
