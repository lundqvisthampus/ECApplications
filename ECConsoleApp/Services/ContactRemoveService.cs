namespace ECConsoleApp.Services;

public class ContactRemoveService
{

    /// <summary>
    /// Constructor that revieves contactService as an argument, 
    /// implemented so it avoids creating a new instance of the contactService when method from that class is called.
    /// </summary>
    private readonly ContactService contactService;
    public ContactRemoveService (ContactService _contactService)
    {
        contactService = _contactService;
    }


    /// <summary>
    /// Let's the user remove a contact from the list using email.
    /// findContact uses GetContactList method to get the list, and the Find method to get the matching contact with email.
    /// As long as findContact not is null, the contact will be removed from the list in contactService.
    /// </summary>
    public void Remove()
    {
        Console.WriteLine("Enter email of the contact you want to remove from list");
        Console.Write("Email: ");
        string emailToRemove = Console.ReadLine()!;

        var findContact = contactService.GetContactList().Find(contact => contact.Email == emailToRemove);
        if (findContact != null)
        {
            contactService.RemoveContact(findContact);
            Console.Clear();
            Console.WriteLine("Contact removed from list.");
            Console.WriteLine();
        }
        else
        {
            Console.Clear() ;
            Console.WriteLine("Invalid input, or contact not found.");
            Console.WriteLine();
        }

    }
}
