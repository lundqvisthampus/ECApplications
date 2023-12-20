using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ECGraphicApp.Models;
using ECGraphicApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECGraphicApp.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;

    public ContactAddViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }

    [ObservableProperty]
    Contact contact = new Contact();


    [RelayCommand]
    public void SaveContact()
    {
        _contactService.AddContact(Contact);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }
}
