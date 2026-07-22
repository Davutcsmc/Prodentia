using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientsList
{
    public class PatientsFilterDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
