namespace AsanPardakhtTest.Domain.Entities;

public class Person : BaseAuditableEntity
{
    #region Props
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalId { get; private set; }
    public IReadOnlyCollection<Address> Addresses { get; private set; }
    #endregion

    #region Ctor
    private Person() { }

    public Person(string firstName, string lastName, string nationalId)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
    }
    #endregion

    #region Commands
    public static Person Create(string firstName, string lastName, string nationalId)
        => new(firstName, lastName, nationalId);
    #endregion
}
