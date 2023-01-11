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
                .MustAsync(BeUniqueNationalId).WithMessage("The specified NationalId already exists.");
        }

        private bool BeValid(string arg)
        {
            //TODO:Check national id validation!
            return true;
        }

        public async Task<bool> BeUniqueNationalId(string nationalId, CancellationToken cancellationToken)
        {
            return await _context.People
                .AllAsync(x => x.NationalId != nationalId, cancellationToken);
        }
    }
}
