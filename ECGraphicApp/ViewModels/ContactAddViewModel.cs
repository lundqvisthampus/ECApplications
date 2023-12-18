using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ECGraphicApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ECGraphicApp.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;


    public ContactAddViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    Contact contact = new Contact();


    [RelayCommand]
    public void NavigateToList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    public void SaveContact()
    {

    }
}
