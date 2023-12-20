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
    public void NavigateEdit() 
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactEditViewModel>();
    }

    [RelayCommand]
    private void RemoveContact(Contact contact)
    {
        _contactService.RemoveContact(contact);
        ListOfContacts = new ObservableCollection<Contact>(_contactService.GetContactList());
    }
}
