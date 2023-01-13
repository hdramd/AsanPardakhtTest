using AsanPardakhtTest.Application.Common.Models;
using MediatR;

namespace AsanPardakhtTest.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Proviance { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
