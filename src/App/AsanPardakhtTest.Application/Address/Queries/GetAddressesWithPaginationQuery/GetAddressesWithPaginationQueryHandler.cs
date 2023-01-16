using AsanPardakhtTest.Application.Addresses.Queries.Models;
using AsanPardakhtTest.Application.Common.Interfaces;
using AsanPardakhtTest.Application.Common.Mappings;
using AsanPardakhtTest.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Queries.GetAddressesWithPaginationQuery
{
    public class GetAddressesWithPaginationQueryHandler
        : IRequestHandler<GetAddressesWithPaginationQuery, Result<PaginatedList<AddressDto>>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAddressesWithPaginationQueryHandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedList<AddressDto>>> Handle(GetAddressesWithPaginationQuery request,
            CancellationToken cancellationToken)
        {
            var addressQuery = _dbContext.Addresses
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Proviance))
            {
                addressQuery = addressQuery
                    .Where(x => x.Proviance.Contains(request.Proviance));
            }

            if (!string.IsNullOrEmpty(request.City))
            {
                addressQuery = addressQuery
                    .Where(x => x.City.Contains(request.City));
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                addressQuery = addressQuery
                    .Where(x => x.Description.Contains(request.Description));
            }

            var data = await addressQuery
                .ProjectTo<AddressDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return Result.Successfull(data);
        }
    }
}
