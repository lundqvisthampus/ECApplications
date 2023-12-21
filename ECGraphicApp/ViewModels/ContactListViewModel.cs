using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ECGraphicApp.Models;
using ECGraphicApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ECGraphicApp.ViewModels;

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

    [RelayCommand]
    public void NavigateToAdd()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();
    }

    [RelayCommand]
    public void NavigateEdit(Contact contact) 
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        var contactEditViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
        contactEditViewModel.Contact = contact;

        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
    }

    [RelayCommand]
    public void NavigateToInfo(Contact contact)
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();

        var contactInfoViewModel = _serviceProvider.GetRequiredService<ContactInfoViewModel>();
        contactInfoViewModel.Contact = contact;

        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactInfoViewModel>();
    }

    [RelayCommand]
    private void RemoveContact(Contact contact)
    {
        _contactService.RemoveContact(contact);
        ListOfContacts = new ObservableCollection<Contact>(_contactService.GetContactList());
    }
}
