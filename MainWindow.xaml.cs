using System.Windows;
using Bokhandel_WPF_Applikation.ViewModels;

namespace Bokhandel_WPF_Applikation;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}