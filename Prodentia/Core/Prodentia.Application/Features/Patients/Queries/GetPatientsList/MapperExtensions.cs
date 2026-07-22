using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientsList
{
    internal static class MapperExtensions
    {
        internal static PatientListDTO ToDTO(this Patient patient)
        {
            return new PatientListDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value
            };
        }
    }
}
