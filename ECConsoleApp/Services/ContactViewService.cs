namespace ECConsoleApp.Services;
/// <summary>
///  Lets the user view all contacts or more specific info about a single contact from the list in ContactService.
/// </summary>
public class ContactViewService
{
    private readonly ContactService contactService;
    public ContactViewService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    public void ViewAllContacts()
    {
        // Loops through all the contacts in the list in ContactService.
        foreach(var contact in contactService.GetContactList())
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"<{contact.Email}>");
            Console.WriteLine();
        }
        Console.Write("View more details about a specific contact? (y/n): ");
        string option = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(option))
        {
            switch (option)
            {
                case "y":
                    ViewSingleContact();
                    break;

                case "n":
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input, please enter 'y' for yes, and 'n' for no.");
                    Console.WriteLine();
                    break;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please enter 'y' for yes, and 'n' for no.");
            Console.WriteLine();
        }
    }

    public void ViewSingleContact()
    {
        Console.WriteLine("Please enter the email of the contact you want to view.");
        Console.Write("Email: ");
        string contactEmail = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(contactEmail))
        {
            // Using a "find" method to search for a contact in the list in ContactService by using email.
            var findContact = contactService.GetContactList().Find(contact => contact.Email == contactEmail);
            if (findContact != null)
            {
                Console.WriteLine($"\nFirstname: {findContact.FirstName}");
                Console.WriteLine($"Lastname: {findContact.LastName}");
                Console.WriteLine($"Email: {findContact.Email}");
                Console.WriteLine($"Address: {findContact.Address}");
                Console.WriteLine($"Phonenumber: {findContact.PhoneNumber}");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Contact was not found.");
                Console.WriteLine();
            }
        }
    }
}
