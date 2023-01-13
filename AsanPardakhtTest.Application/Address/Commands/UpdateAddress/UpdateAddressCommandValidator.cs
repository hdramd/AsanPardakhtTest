using AsanPardakhtTest.Application.Common.Interfaces;
using FluentValidation;

namespace AsanPardakhtTest.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        public UpdateAddressCommandValidator(IApplicationDbContext dbContext,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;

            RuleFor(x => x.Proviance)
                .NotEmpty().WithMessage("Proviance is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.Id)
                .Must(BeExist).WithMessage("The address dose not exist.")
                .Must(BeOwnerOfAddress).WithMessage("The address is not yours.");//TODO:Use MustAsync
        }

        private bool BeExist(int id)
        {
            var address = _dbContext.Addresses
                .FirstOrDefault(x => x.Id == id);

            return address != null;
        }

        private bool BeOwnerOfAddress(int id)
        {
            var address = _dbContext.Addresses
                   .FirstOrDefault(x => x.Id == id);

            return address != null
                && address.CreatedBy == _currentUserService.UserId;
        }
    }
}
