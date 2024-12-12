

namespace Music.Domain.Models;

public class Artist : Searchable<int>
{
    public string Nickname { get; set; } = null!;
    
    public List<Album> Albums { get; set; } = new ();
    public List<Song> Songs { get; set; } = new ();

    public override string GetTarget() => Nickname;

    public override string ToString() => $"{Nickname}";
}