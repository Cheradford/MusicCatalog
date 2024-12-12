using System.Windows.Media;
using HandyControl.Themes;
using Music.Infrastructure.Service;

namespace Music.View;

using System.Windows;
using HandyControl;
public class App : Application
{
    Service Service;
    public App(Service service)
    {
        Service = service;
        Resources.MergedDictionaries.Add(new Theme());
        Resources.MergedDictionaries.Add(new ThemeResources());
        ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;

    }
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow(Service);
        MainWindow.Show();  // отображаем главное окно на экране
        ShutdownMode = ShutdownMode.OnMainWindowClose;
        base.OnStartup(e);
    }
}