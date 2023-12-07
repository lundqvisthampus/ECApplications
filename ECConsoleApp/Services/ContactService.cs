using ECConsoleApp.Models;

namespace ECConsoleApp.Services;

public class ContactService
{
    private List<Contact> contactList = new();

    public void AddContact(Contact contact)
    {
        contactList.Add(contact);
    }

    public List<Contact> GetContactList()
    {
        return contactList;
    }

    public void RemoveContact(Contact contact)
    {
        contactList.Remove(contact);
    }
}
