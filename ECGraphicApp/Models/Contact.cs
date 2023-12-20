using ECGraphicApp.Interfaces;

namespace ECGraphicApp.Models;

/// <summary>
/// A class with properties implemented from the IContact interface.
/// </summary>
public class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
}
