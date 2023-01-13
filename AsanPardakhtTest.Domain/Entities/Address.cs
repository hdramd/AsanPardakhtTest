namespace AsanPardakhtTest.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        #region Props
        public string Proviance { get; private set; }
        public string City { get; private set; }
        public string Description { get; private set; }
        #endregion

        #region Ctor
        private Address() { }

        public Address(string proviance,
            string city, string description)
        {
            Proviance = proviance;
            City = city;
            Description = description;
        }
        #endregion

        #region Commands
        public static Address Create(string proviance,
            string city, string description)
            => new(proviance, city, description);

        public void Update(string proviance,
            string city, string description)
        {
            Proviance = proviance;
            City = city;
            Description = description;
        }
        #endregion
    }
}
