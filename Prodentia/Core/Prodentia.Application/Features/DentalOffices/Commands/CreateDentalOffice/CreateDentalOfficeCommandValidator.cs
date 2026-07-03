using FluentValidation;

namespace Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandValidator : AbstractValidator<CreateDentalOfficeCommand>
    {
        public CreateDentalOfficeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name cannot be null.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");
        }
    }
}
