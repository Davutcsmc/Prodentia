using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Commands.UpdateDentist
{
    public class UpdateDentistCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
