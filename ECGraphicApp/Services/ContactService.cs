using ECGraphicApp.Interfaces;
using ECGraphicApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ECGraphicApp.Services;

/// <summary>
/// Initialacing a new instace of Fileservice with a filepath as parameter.
/// </summary>
public class ContactService : IContactService
{
    private readonly FileService fileService = new FileService(@"C:\Coding\EC-code\CSharp\ECApplications\ECGraphicApp\Contactlist.json");
    private List<Contact> contactList = new();


    /// <summary>
    /// Method that tries to add the contact to contactList when called as long as Firstname, lastname and email isnt null or whitespace. Else an error will be displayed in the output.
    /// Also tries to convert the contactlist to Json and calls the SaveContentToFile method to save.
    /// </summary>
    public void AddContact(Contact contact)
    {
        if (!string.IsNullOrWhiteSpace(contact.FirstName) && !string.IsNullOrWhiteSpace(contact.LastName) && !string.IsNullOrWhiteSpace(contact.Email))
        {
            try
            {
                contactList.Add(contact);
                fileService.SaveContentToFile(JsonConvert.SerializeObject(contactList));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
        else
        {
            Debug.WriteLine("Failed to update contact. Required fields are missing inputs");
        }
    }

    /// <summary>
    /// Tries to use the GetContentFromFile method and save it as "content" and if the file isnt an empty string or null, it converts the Jsonformated file to the contactList.
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


    /// <summary>
    /// Lets the user update the information for the contact. Firstname, lastname and email is required to not be empty.
    /// Then adds the updated contact to the list, and removes the old one.
    /// If the required inputs are invalid, the output will display an error message. 
    /// </summary>
    public void UpdateContact(Contact contact)
    {

        if (!string.IsNullOrWhiteSpace(contact.FirstName) && !string.IsNullOrWhiteSpace(contact.LastName) && !string.IsNullOrWhiteSpace(contact.Email))
        {
            var updatedContact = contact;

            AddContact(updatedContact);
            RemoveContact(contact);
        }
        else
        {
            Debug.WriteLine("Failed to update contact. Required fields are missing inputs");
        }
    }

}
