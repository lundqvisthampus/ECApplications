using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ECGraphicApp.Models;
using ECGraphicApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ECGraphicApp.ViewModels;

/// <summary>
/// Using the serviceprovider for dependency injection. 
/// Constructor initializes a new Observablecollection of the list, and gets the list from the GetContactList method in ContactService.
/// </summary>
public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;

    public ContactListViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        ListOfContacts = new ObservableCollection<Contact>(_contactService.GetContactList());
    }

    [ObservableProperty]
    private ObservableCollection<Contact> _listOfContacts = [];


    /// <summary>
    /// Changes the viewmodel to the ContactAddViewModel, where the user can add a new contact to the list.
    /// </summary>
    [RelayCommand]
    public void NavigateToAdd()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();
    }


    /// <summary>
    /// Changes the viewmodel to the ContactEditViewModel, where the user can update the properties of the chosen contact.
    /// 
    /// contactEditViewModel.Contact = contact; makes sure that the same contact chosen in the list, will be the current contact in ContactEditViewModel.
    /// </summary>
    [RelayCommand]
    public void NavigateEdit(Contact contact) 
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        var contactEditViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
        contactEditViewModel.Contact = contact;

        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
    }


    /// <summary>
    /// Changes the viewmodel to the ContactInfoViewModel, where the user can view all the properties of the chosen contact.
    /// 
    /// contactInfoViewModel.Contact = contact; makes sure that the same contact chosen in the list, will be the current contact in ContactEditViewModel.
    /// </summary>
    [RelayCommand]
    public void NavigateToInfo(Contact contact)
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        var contactInfoViewModel = _serviceProvider.GetRequiredService<ContactInfoViewModel>();
        contactInfoViewModel.Contact = contact;

        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactInfoViewModel>();
    }


    /// <summary>
    /// Lets the user remove a contact from the list, and then updates the list to show the new updated list.
    /// </summary>
    [RelayCommand]
    private void RemoveContact(Contact contact)
    {
        _contactService.RemoveContact(contact);
        ListOfContacts = new ObservableCollection<Contact>(_contactService.GetContactList());
    }
}
