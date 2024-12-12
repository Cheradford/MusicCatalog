using System.Windows;
using HandyControl.Controls;
using Music.Domain.Models;
using Music.Infrastructure.Service;
using Window = System.Windows.Window;

namespace Music.View.Frames.Application;

public partial class CreateAlbum : Window
{
    private Service Service;
    public CreateAlbum(Service service)
    {
        Service = service;
        InitializeComponent();
        Artist.AddRange(Service.GetAllArtists().Result.CreateCheckComboBoxItem());
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        var title = Title.Text;
        var artist = (Artist.SelectedItem as CheckComboBoxItem).Content as Artist;
        var album = new Album{Title = title, Author = artist, AuthorId = artist.Id};
        
        var ent = Service.CreateAlbum(album).Result;
    }
}