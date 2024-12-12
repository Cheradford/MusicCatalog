using Music.Domain.Search;

namespace Music.Domain.Models;

public class Song : Searchable<int>
{
    public string Title { get; set; } = null!;
    
    public string? Path { get; set; }
    
    public int AlbumId { get; set; }
    public Album? Album { get; set; }
    
    public string GenreId { get; set; }
    public Genre Genre { get; set; }
    
    public List<Playlist>? Playlists { get; set; }
    public List<Artist>? Artists { get; set; }

    public void AddArtist(Artist? artist)
    {
        if(artist == null) return;
        Artists ??= new List<Artist>();
        if(!Artists.Contains(artist)) Artists.Add(artist);
    }

    public void RemoveArtist(Artist? artist)
    {
        if(artist == null) return;
        Artists ??= new List<Artist>();
        if(Artists.Contains(artist)) Artists.Remove(artist);
    }

    public void SetGenre(Genre genre)
    {
        if(genre == null) return;
        Genre ??= genre;
        GenreId = genre.Id;
    }
    public override bool Preproccess(Request request)
    {
        if (request.Genre != null)
        {
            return (GenreId == request.Genre);
        }
        return true;
    }

    public override string GetTarget() => Title;
}