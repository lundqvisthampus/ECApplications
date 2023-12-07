using ECConsoleApp.Models;
using System.ComponentModel.Design;

namespace ECConsoleApp.Services;
/// <summary>
/// Lets the user create a contact, and add it to the list in ContactService.
/// </summary>
public class ContactCreateService
{

    private readonly ContactService contactService;

    public ContactCreateService(ContactService _contactService)
    {
        contactService = _contactService;
    }
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

            // Tries to convert string to int, if it fails, the error message will appear. Otherwise it adds the phonenumber to the contact.
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
            // Adds the contact created above, to the list in ContactService using the AddContact method.
           contactService.AddContact(contact);
    }
}
