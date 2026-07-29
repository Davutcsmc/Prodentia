using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQuery: IRequest<PatientDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
