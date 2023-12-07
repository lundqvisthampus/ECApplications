namespace ECConsoleApp.Services;

public class ContactViewService
{
    private readonly ContactService contactService;
    public ContactViewService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    public void ViewAllContacts()
    {
        foreach(var contact in contactService.GetContactList())
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"<{contact.Email}>");
        }
        Console.Write("View more details about a specific contact? (y/n): ");
        string option = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(option))
        {
            if (option == "y")
                ViewSingleContact();
        }
        else
            Console.WriteLine("Invalid input, please enter 'y' for yes, and 'n' for no.");
    }

    public void ViewSingleContact()
    {
        Console.WriteLine("Please enter the email of the contact you want to view.");
        Console.Write("Email: ");
        string contactEmail = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(contactEmail))
        {
            var findContact = contactService.GetContactList().Find(contact => contact.Email == contactEmail);
            if (findContact != null)
            {
                Console.WriteLine($"\n{findContact.FirstName} {findContact.LastName}");
                Console.WriteLine($"{findContact.Email}");
                Console.WriteLine($"{findContact.Address}");
                Console.WriteLine($"{findContact.PhoneNumber}");
            }
        }
    }
}
