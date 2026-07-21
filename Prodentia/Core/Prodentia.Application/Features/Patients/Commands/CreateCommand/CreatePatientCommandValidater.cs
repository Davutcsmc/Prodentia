using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Commands.CreateCommand
{
    public class CreatePatientCommandValidater : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidater() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required.")
                .MaximumLength(250).WithMessage("The field {PropertyName} cannot exceed 250 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The field {PropertyName} is required.")
                .EmailAddress().WithMessage("The field {PropertyName} must be a valid email address.");
        }
    }
}
