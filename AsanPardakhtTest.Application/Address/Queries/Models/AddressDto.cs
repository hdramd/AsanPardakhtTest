using AsanPardakhtTest.Application.Common.Mappings;
using AsanPardakhtTest.Domain.Entities;

namespace AsanPardakhtTest.Application.Addresses.Queries.Models
{
    public class AddressDto : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Proviance { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
