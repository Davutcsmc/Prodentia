using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Commands.DeleteDentalOffice
{
    public class DeleteDentalOfficeCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
