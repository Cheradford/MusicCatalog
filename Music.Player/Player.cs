using LibVLCSharp.Shared;

namespace Music.Audio;

public class Player
{
    private List<string>? Playlist { get; set; }
    private int Index { get; set; }
    private MediaPlayer MediaPlayer { get; set; }
    private LibVLC LibVLC { get; set; }
    public float Position => MediaPlayer.Position;
    public bool IsPlaying => MediaPlayer.IsPlaying;
    public bool isEmpty => Playlist is null || Playlist.Count == 0;
    public Player()
    {
        LibVLC = new LibVLC();
        MediaPlayer = new MediaPlayer(LibVLC);

        Core.Initialize();
    }

    public void SetPlaylist(List<String> playlist)
    {
        if (MediaPlayer.IsPlaying) MediaPlayer.Stop();
        Index = 0;
        playlist = playlist.Where(path => path.Length > 0 && File.Exists(path)).ToList();
        Playlist = playlist;
    }

    public void Play()
    {
        if (Playlist is not null)
        {
            if (MediaPlayer.Media == null)
            {
                Index = 0;
                var path = Playlist[Index];
                var media = new Media(LibVLC, path);
                MediaPlayer.Play(media);
            }
            MediaPlayer.Play();
            
        }
    }
    
    public void Pause() => MediaPlayer.Pause();
    public void Stop() => MediaPlayer.Stop();
}