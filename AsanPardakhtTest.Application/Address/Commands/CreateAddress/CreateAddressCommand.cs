using AsanPardakhtTest.Application.Common.Models;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<Result<int>>
    {
        //TODO:Read person id in another way!
        public int PersonId { get; set; }
        public string Proviance { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
