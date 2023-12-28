using ECConsoleApp.Models;

namespace ECConsoleApp.Interfaces;

/// <summary>
/// Interface for the ContactService class. Like a "contract" that the class has to follow/implement.
/// </summary>

internal interface IContactService
{
    public void AddContact(Contact contact);

    public List<Contact> GetContactList();

    public void RemoveContact(Contact contact);
}
