using Prodentia.Application.Utilities;
using Prodentia.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery: PatientsFilterDTO, IRequest<PaginatedDTO<PatientListDTO>>
    {

    }
}
