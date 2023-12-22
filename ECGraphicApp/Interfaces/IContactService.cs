using ECGraphicApp.Models;

namespace ECGraphicApp.Interfaces;

/// <summary>
/// Interface for the contactservice. All methods below needs to be implemented to the contactservice class.
/// </summary>
internal interface IContactService
{
    public void AddContact(Contact contact);

    public List<Contact> GetContactList();

    public void RemoveContact(Contact contact);

    public void UpdateContact(Contact contact);

}
