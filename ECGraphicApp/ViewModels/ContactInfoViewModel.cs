﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ECGraphicApp.Models;
using ECGraphicApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECGraphicApp.ViewModels;

public partial class ContactInfoViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;

    public ContactInfoViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }

    [ObservableProperty]
    private Contact _contact = new();


    [RelayCommand]
    public void BackToList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }
}
