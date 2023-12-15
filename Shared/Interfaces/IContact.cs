namespace Shared.Interfaces;

/// <summary>
/// Interface for the contact class. "Contract" that the class has to follow.
/// </summary>
public interface IContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Address { get; set; }
}
