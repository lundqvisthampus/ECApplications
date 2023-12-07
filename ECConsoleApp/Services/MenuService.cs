namespace ECConsoleApp.Services;

public class MenuService
{
    /// <summary>
    /// Lets the user choose an option from the main menu. 
    /// If the user input is not an empty string or null, the program moves on as expected.
    /// If the input is an empty string or null, an error message will appear.
    /// </summary>
    /// 

    private readonly ContactService contactService;

    public MenuService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    public void ShowMenu()
    {
        // Making sure that all services uses the same instance of ContactService.
        ContactCreateService contactCreate = new ContactCreateService(contactService);
        ContactViewService contactView = new ContactViewService(contactService);
        ContactRemoveService contactRemove = new ContactRemoveService(contactService);

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

            // Checks that the input is not an empty string or null.
            if (!string.IsNullOrEmpty(option))
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("### ADD NEW CONTACT ###");
                        contactCreate.Add();
                        Console.Clear();
                        Console.WriteLine("Contact added!");
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("### ALL CONTACTS IN LIST ###");
                        Console.WriteLine();
                        contactView.ViewAllContacts();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("### VIEW SPECIFIC CONTACT IN LIST ###");
                        contactView.ViewSingleContact();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("### REMOVE A CONTACT FROM LIST ###");
                        contactRemove.Remove();
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
