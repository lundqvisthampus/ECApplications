using CommunityToolkit.Mvvm.ComponentModel;

namespace ECGraphicApp.ViewModels;

public partial class ContactEditViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ContactEditViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
