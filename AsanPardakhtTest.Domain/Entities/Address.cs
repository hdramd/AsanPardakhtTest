namespace AsanPardakhtTest.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        #region Props
        public string Proviance { get; private set; }
        public string City { get; private set; }
        public string Description { get; private set; }
        public int PersonId { get; private set; }
        public virtual Person Person { get; private set; }
        #endregion

        #region Ctor
        private Address() { }

        public Address(int personId, string proviance,
            string city, string description)
        {
            PersonId = personId;
            Proviance = proviance;
            City = city;
            Description = description;
        }
        #endregion

        #region Commands
        public static Address Create(int personId, string proviance,
            string city, string description)
            => new(personId, proviance, city, description);

        public void Update(int personId, string proviance,
            string city, string description)
        {
            PersonId = personId;
            Proviance = proviance;
            City = city;
            Description = description;
        }
        #endregion
    }
}
