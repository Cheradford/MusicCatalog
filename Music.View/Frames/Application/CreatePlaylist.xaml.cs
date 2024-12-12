using System.Windows;
using HandyControl.Controls;
using Music.Domain.Models;
using Music.Infrastructure.Service;
using Window = System.Windows.Window;

namespace Music.View.Frames.Application;

public partial class CreatePlaylist : Window
{
    private Service Service;
    public CreatePlaylist(Service service)
    {
        Service = service;
        Songs.AddRange(service.GetAllSongs().Result);
        InitializeComponent();
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        var title = Title.Text;
        var songs = Songs.SelectedItems.Cast<Song>().ToList();

        var playlist = new Playlist{Title = title, Songs = songs};
        playlist = Service.CreatePlaylist(playlist).Result;
        Close();
    }
}