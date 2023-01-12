using System;
namespace AsanPardakhtTest.Client.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Proviance { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
