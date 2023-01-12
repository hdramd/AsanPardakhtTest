using AsanPardakhtTest.Application.Addresses.Queries.Models;
using AsanPardakhtTest.Application.Common.Interfaces;
using AsanPardakhtTest.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AsanPardakhtTest.Application.Addresses.Queries.GetAddressesByProviance;

public class GetAddressesByProvianceQueryHandler : IRequestHandler<GetAddressesByProvianceQuery, Result<List<AddressDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    public GetAddressesByProvianceQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<AddressDto>>> Handle(GetAddressesByProvianceQuery request,
        CancellationToken cancellationToken)
    {
        //TODO:Return data as paginated list
        var addresses = await _dbContext.Addresses
               .Where(x => x.Proviance.ToLower().Trim().Equals(request.Proviance.ToLower().Trim())
                   && x.Created >= DateTime.Now.AddMinutes(-10))
               .Select(x => new AddressDto
               {
                   Id = x.Id,
                   Proviance = x.Proviance,
                   City = x.City,
                   Description = x.Description,
                   Created = x.Created
               }).ToListAsync(cancellationToken: cancellationToken);

        return Result.Successfull(addresses);
    }
}
