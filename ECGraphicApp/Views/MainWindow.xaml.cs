using ECGraphicApp.ViewModels;
using System.Windows;

namespace ECGraphicApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}