using System.Windows;
using System.Windows.Controls;
using HandyControl.Controls;
using Microsoft.Win32;
using Music.Domain.Models;
using Music.Infrastructure.Service;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = HandyControl.Controls.MessageBox;
using Window = System.Windows.Window;


namespace Music.View.Frames.Application;

public partial class WindowSong : Window
{
    private Service Service;
    private Song Entity;
    private Action<object, RoutedEventArgs>? Action;

    public WindowSong(Service service, OperationType type, Song? entity = null)
    {
        Service = service;
        InitializeComponent();
        var boxes = CreateCheckBox(Service.GetAllArtists().Result);
        foreach (var box in boxes)
        {
            Artists.Items.Add(box);
        }

        GenreSelect.ItemsSource = Service.GetAllGenres().Result;
    }

    private IEnumerable<RadioButton> CreateRadioButton(IEnumerable<Genre> genres)
    {
        foreach (var genre in genres)
        {
            var rButton = new RadioButton();
            rButton.Content = genre;
            rButton.GroupName = "Genres";
            rButton.Checked += RadioButton_OnClick;
            yield return rButton;
        }
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var box = sender as ComboBox;
        if (box != null && box.SelectedItem is Artist)
        {
            Entity.AddArtist(box.SelectedItem as Artist);
        }
    }

    private IEnumerable<CheckComboBoxItem> CreateCheckBox(IEnumerable<Artist> artists)
    {
        foreach (var artist in artists)
        {
            var checkBox = new CheckComboBoxItem();
            checkBox.Content = artist;
            //checkBox.Checked += CheckBox_OnClick;
            yield return checkBox;
        }
    }


    private void CheckBox_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is CheckBox checkBox)
        {
            if (checkBox.Content is Artist artist)
            {
                if (checkBox.IsChecked.HasValue && checkBox.IsChecked.Value)
                {
                    Entity.AddArtist(artist);
                    return;
                }

                Entity.RemoveArtist(artist);
            }
        }
    }

    private void RadioButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton radioButton)
        {
            if (radioButton.Content is Genre genre)
            {
                if (radioButton.IsChecked.HasValue && radioButton.IsChecked.Value)
                {
                    Entity.Genre = genre;
                }
            }
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var fileDialog = new OpenFileDialog()
        {
            Filter = "Аудиофайлы|*.mp3;*.wav;*.flac;*.aac;*.ogg;*.wma|Все файлы|*.*",
            Title = "Выберите файл"
        };

        if (fileDialog.ShowDialog() == true)
        {
            Entity.Path = fileDialog.FileName;
            File.Text = fileDialog.FileName;
        }
    }

    private void Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Action?.Invoke(sender, e);
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                $"{exception.Data}:{exception.Message}", 
                "Exception", 
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }

    private void Create(object sender, RoutedEventArgs e)
    {
        var title = Title.Text;
        var genre = GenreSelect.SelectedItem as Genre;
        var artists = Artists.SelectedItems.Cast<Artist>().ToList();
        var path = File.Text;
        var song = new Song { Title = title, Genre = genre, Artists = artists, Path = path };
        Entity = Service.CreateSong(song).Result;
        Close();
    }

    private void Update(object sender, RoutedEventArgs e)
    {
        var title = Title.Text;
        var genre = GenreSelect.SelectedItem as Genre;
        var artists = Artists.SelectedItems.Cast<Artist>().ToList();
        var path = File.Text;
        var song = new Song { Title = title, Genre = genre, Artists = artists, Path = path };
    }
}