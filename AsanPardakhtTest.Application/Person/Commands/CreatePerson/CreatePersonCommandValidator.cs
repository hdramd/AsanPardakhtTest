using AsanPardakhtTest.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AsanPardakhtTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreatePersonCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(200).WithMessage("FirstName must not exceed 200 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(200).WithMessage("LastName must not exceed 200 characters.");

            RuleFor(v => v.NationalId)
                .NotEmpty().WithMessage("NationalId is required.")
                .Must(BeValid).WithMessage("NationalId is not valid.")
                .Must(BeUniqueNationalId).WithMessage("The specified NationalId already exists.");//TODO:Use MustAsync

        }

        private bool BeValid(string arg)
        {
            //TODO:Check national id validation!
            return true;
        }

        public bool BeUniqueNationalId(string nationalId)
        {
            return !_context.People
                .Any(x => x.NationalId.Equals(nationalId));
        }
    }
}
