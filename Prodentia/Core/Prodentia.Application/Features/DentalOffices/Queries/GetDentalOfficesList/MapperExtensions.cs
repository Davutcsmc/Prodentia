using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    internal static class MapperExtensions
    {
        public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficesListDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
            return dto;
        }
    }
}
