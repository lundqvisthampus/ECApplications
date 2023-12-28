namespace ECGraphicApp.Interfaces;

/// <summary>
/// Interface for the contact class. Like a "ontract" that the class has to follow/implement.
/// </summary>
public interface IContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
