using Music.Domain.Models;

namespace Music.Domain;

public interface IHasArtist
{
    public int AuthorId { get; set; } 
    public Artist Author { get; set; }
}