using Shared.Models;

namespace Shared.Interfaces;

internal interface IContactService
{
    public void AddContact(Contact contact);

    public List<Contact> GetContactList();

    public void RemoveContact(Contact contact);
}
