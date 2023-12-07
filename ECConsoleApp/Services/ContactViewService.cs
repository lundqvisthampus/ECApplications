namespace ECConsoleApp.Services;

public class ContactViewService
{
    /// <summary>
    /// Constructor that revieves contactService as an argument, 
    /// implemented so it avoids creating a new instance of the contactService when method from that class is called.
    /// </summary>
    private readonly ContactService contactService;
    public ContactViewService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    /// <summary>
    /// Method that uses a foreach loop to go through all contacts in the list from the GetContactList method.
    /// Also lets the user view aditional details about a user by entering "y". Then the ViewSingleContact method will be called.
    /// </summary>
    public void ViewAllContacts()
    {
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

    /// <summary>
    /// Lets the user view aditional information about a contact by entering the contacts email.
    /// If the user input is not an empty string or null, the GetContactList method gets called to get the list, 
    /// and the Find method to get the matching contact with email.
    /// </summary>
    public void ViewSingleContact()
    {
        Console.WriteLine("\nPlease enter the email of the contact you want to view.");
        Console.Write("Email: ");
        string contactEmail = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(contactEmail))
        {
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
