using ECGraphicApp.Interfaces;
using ECGraphicApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ECGraphicApp.Services;

/// <summary>
/// Field with a filepath passed as an argument and initializing a new Fileservice.
/// </summary>
public class ContactService : IContactService
{
    private readonly FileService fileService = new FileService(@"C:\Coding\EC-code\CSharp\ECApplications\ECGraphicApp\Contactlist.json");
    private List<Contact> contactList = new();


    /// <summary>
    /// Method that tries to add the contact to contactList when called.
    /// Also tries to convert the contactlist to Json and calls the SaveContentToFile method to save.
    /// </summary>
    public void AddContact(Contact contact)
    {
        try
        {
            contactList.Add(contact);
            fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    /// <summary>
    /// Tries to use the GetContentFromFile method, if the file isnt an empty string or null, it converts the Jsonformated file to the contactList.
    /// </summary>
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

    /// <summary>
    /// Removes contact from the contactList and also converts the list to Json and saves it to file using the
    /// SaveContentToFile method.
    /// </summary>
    public void RemoveContact(Contact contact)
    {
        contactList.Remove(contact);
        fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
    }

    public Contact ShowContactInfo(Contact contact)
    {
        var specificContact = contactList.FirstOrDefault(x => x.LastName == contact.LastName);
        if (specificContact != null)
        {
            return specificContact;
        }
        else
        {
            return null!;
        }
    }

    public void UpdateContact(Contact contact)
    {
        var updateContact = contact;
        AddContact(updateContact);
        RemoveContact(contact);
    }

}
