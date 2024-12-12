using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Music.Infrastructure.Database;
using Music.Infrastructure.Service;
using Music.View.Frames;
using Music.View.Frames.Application;

namespace Music.View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider Services;

    public App()
    {
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        var services = new ServiceCollection();
        ConfigureServices(services);
        Services = services.BuildServiceProvider();
        DispatcherUnhandledException += HandleException;
    }
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<Context>(ob => ob.UseSqlite(@"Data Source=.\Catalog.db"), ServiceLifetime.Singleton);
        services.AddScoped<Service>();
        services.AddScoped<MainWindow>();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var window = Services.GetService<MainWindow>();
        if (window != null)
        {
            MainWindow = window;
            MainWindow.Show();
        }
    }

    protected void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show($"Ошибка: {e.Exception.Message}", "Необработанное исключение");
        e.Handled = true;
        Shutdown();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }
}