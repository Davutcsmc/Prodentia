using Prodentia.Application.Utilities;

namespace Prodentia.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
