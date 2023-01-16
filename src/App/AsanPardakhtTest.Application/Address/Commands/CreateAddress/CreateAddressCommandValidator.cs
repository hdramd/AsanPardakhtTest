using FluentValidation;

namespace AsanPardakhtTest.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Proviance)
                .NotEmpty().WithMessage("Proviance is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");
        }
    }
}
