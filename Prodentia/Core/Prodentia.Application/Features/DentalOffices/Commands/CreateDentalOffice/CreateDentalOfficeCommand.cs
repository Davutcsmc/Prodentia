using Prodentia.Application.Utilities;

namespace Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
