namespace ECConsoleApp.Services;

/// <summary>
/// Lets the user remove a contact from the list in ContactService.
/// </summary>
/// 
public class ContactRemoveService
{
    private readonly ContactService contactService;

    public ContactRemoveService (ContactService _contactService)
    {
        contactService = _contactService;
    }

    public void Remove()
    {
        Console.WriteLine("Enter email of the contact you want to remove from list");
        Console.Write("Email: ");
        string emailToRemove = Console.ReadLine()!;

        // Using a "find" method to search for a contact in the list by email (user input).
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
