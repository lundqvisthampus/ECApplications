using ECConsoleApp.Interfaces;
namespace ECConsoleApp.Models;

/// Contact class, using the IContact interface as a "contract".
public class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; }
    public string Address { get; set; } = null!;
}
