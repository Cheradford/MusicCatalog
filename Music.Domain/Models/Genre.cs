namespace Music.Domain.Models;

public class Genre : ObjectId<string>
{
    public string Title => Id;
    public List<Song> Songs { get; set; } = new ();
    
    public override string ToString() => Title;
}