using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator:AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty().WithMessage("PatientId is required.");
            RuleFor(x => x.DentistId).NotEmpty().WithMessage("DentistId is required.");
            RuleFor(x => x.DentalOfficeId).NotEmpty().WithMessage("DentalOfficeId is required.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate is required.");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("EndDate is required.");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("EndDate must be greater than StartDate.");
        }
    }
}
