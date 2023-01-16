using AsanPardakhtTest.Application.Common.Interfaces;
using AsanPardakhtTest.Application.Common.Models;
using AsanPardakhtTest.Domain.Entities;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Result<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateAddressCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<int>> Handle(CreateAddressCommand request,
            CancellationToken cancellationToken)
        {
            var address = Address.Create(request.Proviance, request.City,
                request.Description);
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Result.Successfull(address.Id);
        }
    }
}
