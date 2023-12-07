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
        ContactCreateService contactCreate = new ContactCreateService(contactService);
        ContactViewService contactView = new ContactViewService(contactService);

        while (true)
        {
            Console.WriteLine("   ----- #####  MENU  ##### -----   ");
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("\n1. Add new contact to list.");
            Console.WriteLine("2. View all contacts in list.");
            Console.WriteLine("4. View specific contact in list.");
            Console.WriteLine("4. Remove a contact from list.");
            Console.WriteLine("5. Exit program.");
            Console.Write("\nEnter chosen option (number): ");
            string option = Console.ReadLine()!;

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
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
        }
    }
}
