using Prodentia.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
