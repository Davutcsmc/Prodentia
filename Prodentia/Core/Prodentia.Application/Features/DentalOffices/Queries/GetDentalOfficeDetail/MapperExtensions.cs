using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    internal static class MapperExtensions
    {
        public static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
            return dto;
        }
    }
}
