using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bokhandel_WPF_Applikation.Models;
using Bokhandel_WPF_Applikation.ViewModels;

namespace Bokhandel_WPF_Applikation;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();

        services.AddDbContext<BokhandelContext>(options =>
            options.UseSqlServer(
                "Server=localhost;Database=Bokhandel_Labb;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MainWindow>();

        var serviceProvider = services.BuildServiceProvider();

        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
