namespace AsanPardakhtTest.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        public string Proviance { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
