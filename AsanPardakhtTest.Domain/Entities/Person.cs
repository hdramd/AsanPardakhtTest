using AsanPardakhtTest.Domain.Common;

namespace AsanPardakhtTest.Domain.Entities
{
    public class Person : BaseAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Address> Addresses { get; set; }
    }
}
