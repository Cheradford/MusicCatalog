using System.Windows;
using Music.Domain.Models;
using Music.Infrastructure.Service;

namespace Music.View.Frames.Application;

public partial class CreateArtist : Window
{
    Service Service;
    public CreateArtist(Service service)
    {
        Service = service;
        InitializeComponent();
    }

    private void AddArtist(object sender, RoutedEventArgs e)
    {
        try
        {
            var nickname = Nickname.Text;
            var name = Name.Text;
            var surname = Surname.Text;
            var artist = new Artist(){Nickname = nickname};
            MessageBox.Show($"Исполнитель {artist.Nickname} (id={artist.Id}) успешно добавлен");
        }
        catch (Exception exception)
        {
            MessageBox.Show($"{exception.Source}:{exception.Message}");
        }
        Close();
        
    }
}