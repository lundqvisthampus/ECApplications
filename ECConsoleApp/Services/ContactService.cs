using ECConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ECConsoleApp.Services;

/// <summary>
/// Different methods used for managing the list of contacts and also saving it to json formated file..
/// </summary>
public class ContactService
{
    private readonly FileService fileService = new FileService(@"C:\Coding\EC-code\CSharp\ECApplications\ECConsoleApp\Contactlist.json");
    private List<Contact> contactList = new();

    // Adding the contact to contactList.
    // Converting the list to Json, and using SaveContentToFile to save it.
    public void AddContact(Contact contact)
    {
        try
        {
            contactList.Add(contact);
            fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    // Deserializing the Json file to the contactList.
    public List<Contact> GetContactList()
    {
        try
        {
            var content = fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content)) 
            {
                contactList = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return contactList; 
    }

    // Removing a contact from the list, and saving the updated list as Json.
    public void RemoveContact(Contact contact)
    {
        contactList.Remove(contact);
        fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
    }
}
