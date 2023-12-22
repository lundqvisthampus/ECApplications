using ECGraphicApp.Services;
using ECGraphicApp.ViewModels;
using ECGraphicApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ECGraphicApp;

/// <summary>
/// Using dependency injection to make sure that the same instance of the viewmodels is used everywhere it is needed.
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<ContactService>();
                services.AddSingleton<FileService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactListView>();
                services.AddTransient<ContactAddViewModel>();
                services.AddTransient<ContactAddView>();
                services.AddSingleton<ContactInfoViewModel>();
                services.AddSingleton<ContactInfoView>();
                services.AddSingleton<ContactEditViewModel>();
                services.AddSingleton<ContactEditView>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
