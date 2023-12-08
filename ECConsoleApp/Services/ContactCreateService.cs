using ECConsoleApp.Interfaces;
using ECConsoleApp.Models;
using System.ComponentModel.Design;

namespace ECConsoleApp.Services;

public class ContactCreateService
{

    /// <summary>
    /// Constructor that revieves contactService as an argument, 
    /// implemented so it avoids creating a new instance of the contactService when method from that class is called.
    /// </summary>
    private readonly IContactService contactService;
    public ContactCreateService(ContactService _contactService)
    {
        contactService = _contactService;
    }

    /// <summary>
    /// Function that creates a new contact of the contact class. 
    /// Lets the user set the properties of contact, as long as the input is not null or an empty string.
    /// If the input IsNullOrEmpty, the user will get another try at the input. If not, the loop will break and continue onto the next while-loop.
    /// </summary>
    public void Add()
    {
        Contact contact = new Contact();

        while (true)
        {
            Console.Write("Firstname: ");
            string firstName = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(firstName))
            {
                contact.FirstName = firstName;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }

        while (true)
        {
            Console.Write("Lastname: ");
            string lastName = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(lastName))
            {
                contact.LastName = lastName;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }

        while (true)
        {
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(email))
            {
                contact.Email = email;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }


        while (true)
        {
            Console.Write("Phonenumber: ");
            string phoneNumberInput = Console.ReadLine()!;
            if (string.IsNullOrEmpty(phoneNumberInput))
            {
                Console.WriteLine("Invalid input, try again.");
            }

            /// Tries to convert the input string to an int. If the input is a letter (a-ö). It will run the loop again until a number is added instead.
            else if (!int.TryParse(phoneNumberInput, out int phoneNumber))
            {
                Console.WriteLine("Invalid input, try again.");
            }
            else
            {
                contact.PhoneNumber = phoneNumber;
                break;
            }
        }

        while (true)
        {
            Console.Write("Address: ");
            string address = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(address))
            {
                contact.Address = address;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }
            /// Adds the contact created above, to the list in ContactService using the AddContact method.
            /// Also saves it as Json to a file.
           contactService.AddContact(contact);
    }
}
