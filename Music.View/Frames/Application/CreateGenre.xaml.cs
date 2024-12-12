using System.Windows;
using System.Windows.Controls;
using Music.Domain.Models;
using Music.Infrastructure.Service;

namespace Music.View.Frames.Application;

public partial class CreateGenre : Window
{
    Service Service;

    public CreateGenre(Service service)
    {
        Service = service;
        InitializeComponent();
    }

    private void AddNewGenre(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            try
            {
                button.IsEnabled = false;
                var title = TextBox.Text;
                var ent = Service.CreateGenre(title).Result;
                MessageBox.Show($"Жанр \"{ent.Title}\" успешно создан");
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Source+":"+exception.Message);
            }
            button.IsEnabled = true;
        }
    }
}