

namespace Music.Domain.Models;
public class Playlist : Searchable<int>
{
    public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string Title { get; set; }
    public List<Song> Songs = new(); 
    public override string GetTarget() => Title;


}