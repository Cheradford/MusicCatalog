using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Music.Infrastructure.Database;
using Music.Infrastructure.Service;
using Music.View.Frames.Application;

namespace Music.View;

public class Program
{
    [STAThread]
    public static void Main()
    {
        // создаем хост приложения
        var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices(services =>
            {
                services.AddDbContext<Context>(ob => ob.UseSqlite(@"Data Source=.\Catalog.db"), ServiceLifetime.Singleton);
                services.AddScoped<Service>();
                services.AddScoped<MainWindow>();
                services.AddScoped<App>();
            })
            .Build();
        // получаем сервис - объект класса App
        var app = host.Services.GetService<App>();
        // запускаем приложения
        app?.Run();
    }
}