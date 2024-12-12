using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Controls;
using Music.Audio;
using Music.Infrastructure.Service;
using Music.View.Frames;
using Music.View.Frames.Application;
using Window = System.Windows.Window;

namespace Music.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Service Service;
    private Player Player;

    public MainWindow(Service service)
    {
        Service = service;
        Player = new Player();
        InitializeComponent();
        var columnsCount = 3;
        var buttons = Service.GetAllGenres().Result.CreateButton().ToList();
        var rowLength = buttons.Count / columnsCount;
        for (int i = 0; i < buttons.Count; i+=columnsCount)
        {
            var row = new Row();
            
            var columns = buttons.Skip(i).Take(columnsCount).Select(but =>
            {
                var col = new Col();
                col.Span = 24 / columnsCount;
                col.Content = but;
                return col;
            });
            row.Children.AddRange(columns);
            Genres.Children.Add(row);
        }
    }


    public void Play(object sender, RoutedEventArgs e)
    {
        if (Player.isEmpty)
        {
            Player.SetPlaylist(new() { @"I:\dajte-tank-malenkij-mp3.mp3" });
        }

        if (Player.IsPlaying)
        {
            Player.Pause();
        }
        else
        {
            Player.Play();
        }
    }

    public void MakeGenreCreateWindow(object sender, RoutedEventArgs e)
    {
        var genreWindow = new CreateGenre(Service);
        genreWindow.Owner = this;
        genreWindow.ShowDialog();
    }
    
    public void MakeAlbumCreateWindow(object sender, RoutedEventArgs e)
    {
        var genreWindow = new CreateAlbum(Service);
        genreWindow.Owner = this;
        genreWindow.ShowDialog();
    }

    public void MakeArtistCreateWindow(object sender, RoutedEventArgs e)
    {
        var artistWindow = new CreateArtist(Service);
        artistWindow.Owner = this;
        artistWindow.ShowDialog();
    }

    public void CreateSongButton(object sender, RoutedEventArgs e)
    {
        var window = new WindowSong(Service, OperationType.Create);
        window.Owner = this;
        window.ShowDialog();
    }

    private void CreatePlaylist(object sender, RoutedEventArgs e)
    {
        var window = new CreatePlaylist(Service);
        window.Owner = this;
        window.ShowDialog();
    }
}