namespace ECConsoleApp.Services;

public class MenuService
{
    /// <summary>
    /// Constructor that revieves contactService as an argument, 
    /// implemented so it avoids creating a new instance of the contactService when method from that class is called.
    /// </summary>

    private readonly ContactService contactService;
    public MenuService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    /// <summary>
    /// Method that loops through the menu options. 
    /// Using dependency injection to make sure that all services uses the same instance of contactService.
    /// As long as the input is not empty, a switch based on the user input will be used.
    /// Each case has different methods which will be called based on the user input.
    /// </summary>
    public void ShowMenu()
    {
        ContactCreateService contactCreateService = new ContactCreateService(contactService);
        ContactViewService contactViewService = new ContactViewService(contactService);
        ContactRemoveService contactRemoveService = new ContactRemoveService(contactService);

        while (true)
        {
            Console.WriteLine("   ----- #####  MENU  ##### -----   ");
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("\n1. Add new contact to list.");
            Console.WriteLine("2. View all contacts in list.");
            Console.WriteLine("3. View specific contact in list.");
            Console.WriteLine("4. Remove a contact from list.");
            Console.WriteLine("5. Exit program.");
            Console.Write("\nEnter option (number): ");
            string option = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(option))
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("### ADD NEW CONTACT ###");
                        contactCreateService.Add();
                        Console.Clear();
                        Console.WriteLine("Contact added!");
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("### ALL CONTACTS IN LIST ###");
                        Console.WriteLine();
                        contactViewService.ViewAllContacts();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("### VIEW SPECIFIC CONTACT IN LIST ###");
                        contactViewService.ViewSingleContact();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("### REMOVE A CONTACT FROM LIST ###");
                        contactRemoveService.Remove();
                        break;

                    case "5":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, choose between option 1-5.");
                        Console.WriteLine();
                        break;
                }   
        }
    }
}
