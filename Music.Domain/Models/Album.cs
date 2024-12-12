using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Domain.Models;

public class Album : Searchable<int>, IHasArtist
{
    public string Title { get; set; }
    public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public List<Song> Songs{ get; set; }= new(); 
    public override string GetTarget() => Title;

    public int AuthorId { get; set; }
    public Artist Author { get; set; }
}