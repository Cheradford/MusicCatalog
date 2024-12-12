using Microsoft.EntityFrameworkCore;
using Music.Domain;
using Music.Domain.Models;
using Music.Infrastructure.Database;

namespace Music.Infrastructure.Service;

public class Service(Context context)
{
    private IRepository<Song, int> SongRepository { get; } = new Repository<Song, int>(context);
    private IRepository<Genre, string> GenreRepository { get; } = new Repository<Genre, string>(context);
    private IRepository<Artist, int> ArtistRepository { get; } = new Repository<Artist, int>(context);
    private IRepository<Album, int> AlbumRepository { get; } = new Repository<Album, int>(context);
    private IRepository<Playlist, int> PlaylistRepository { get; } = new Repository<Playlist, int>(context);
    
    public async Task<IEnumerable<Genre>> GetAllGenres()
    {
        var genres = GenreRepository.Get();
        return genres.AsEnumerable();
    }

    public async Task<Playlist> CreatePlaylist(Playlist playlist)
    {
        var ent = await PlaylistRepository.Add(playlist); 
        return ent;
    }
    
    public async Task<IEnumerable<Artist>> GetAllArtists()
    {
        var artists = ArtistRepository.Get().ToList();
        return artists;
    }
    
    public async Task<IEnumerable<Song>> GetAllSongs()
    {
        var songs = SongRepository.Get().ToList();
        return songs;
    }

    public async Task<Genre> CreateGenre(string name)
    {
        var genre = new Genre { Id = name };
        if (await GenreRepository.IsIdAvailableAsync(name))
        {
            var ent = await GenreRepository.Add(genre);
            return ent;
        }
        
        throw new Exception("Жанр с таким именем уже создан");
    }
    
    public async Task<Song> CreateSong(Song song)
    {
        var ent = await SongRepository.Add(song); 
        return ent;
    }
    
    public async Task<Song> Update(Song song)
    {
        var ent = await SongRepository.Update(song.Id, song);
        return ent;
    }

    public async Task<Album> GetAlbumById(int id)
    {
        var album = await AlbumRepository.GetById(id);
        return album;
    }

    public async Task<Artist> CreateArtist(Artist artist)
    {
        var ent = await ArtistRepository.Add(artist);
        return ent;
    }

    public async Task<Artist> GetArtistById(int id)
    {
        var artist = await ArtistRepository.GetById(id);
        return artist;
    }

    public async Task<Album> CreateAlbum(Album album)
    {
        var ent = await AlbumRepository.Add(album);
        return ent;
    }
}