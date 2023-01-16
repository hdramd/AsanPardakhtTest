using AsanPardakhtTest.Application.Common.Interfaces;
using AsanPardakhtTest.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AsanPardakhtTest.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Result>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateAddressCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(UpdateAddressCommand request, 
            CancellationToken cancellationToken)
        {
            var address = await _dbContext.Addresses
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id),
                    cancellationToken: cancellationToken);

            if (address == null)
                return Result.Failed("Address not found.");

            address.Update(request.Proviance, request.City, 
                request.Description);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Successfull();
        }
    }
}
