using AsanPardakhtTest.Application.Addresses.Queries.Models;
using AsanPardakhtTest.Application.Common.Models;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Queries.GetAddressesWithPaginationQuery
{
    public class GetAddressesWithPaginationQuery : IRequest<Result<PaginatedList<AddressDto>>>
    {
        public string Proviance { get; init; }
        public string City { get; init; }
        public string Description { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
