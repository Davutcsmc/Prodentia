using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator:AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("The field {PropertyName} must be a valid email address.");
        }
    }
}
