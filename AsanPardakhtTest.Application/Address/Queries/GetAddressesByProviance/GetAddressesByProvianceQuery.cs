using AsanPardakhtTest.Application.Addresses.Queries.Models;
using AsanPardakhtTest.Application.Common.Models;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Queries.GetAddressesByProviance
{
    public class GetAddressesByProvianceQuery : IRequest<Result<List<AddressDto>>>
    {
        public string Proviance { get; set; }
    }
}
