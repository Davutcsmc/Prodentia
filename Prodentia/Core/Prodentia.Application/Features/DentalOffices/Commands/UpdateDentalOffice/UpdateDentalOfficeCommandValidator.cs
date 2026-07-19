using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandValidator : AbstractValidator<UpdateDentalOfficeCommand>
    {
        public UpdateDentalOfficeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name cannot be null.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");
        }
    }
}
