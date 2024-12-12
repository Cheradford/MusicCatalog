using Microsoft.EntityFrameworkCore;
using Music.Domain;
using Music.Domain.Models;

namespace Music.Infrastructure.Database;

public class Context : DbContext
{
    
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=.\Catalog.db");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        
        #region Fk
        modelBuilder.Entity<Album>().HasOne(al => al.Author).WithMany(a => a.Albums).HasForeignKey(a => a.AuthorId);
        modelBuilder.Entity<Album>().HasMany(al => al.Songs).WithOne(s => s.Album).HasForeignKey(s => s.AlbumId);
        
        modelBuilder.Entity<Song>().HasMany(s => s.Artists).WithMany(a => a.Songs);
        //modelBuilder.Entity<Song>().HasOne(s => s.Album).WithMany(a => a.Songs).HasForeignKey(s => s.AlbumId);
        modelBuilder.Entity<Song>().HasOne(s => s.Genre).WithMany(g => g.Songs).HasForeignKey(g => g.GenreId);
        
        modelBuilder.Entity<Playlist>().HasMany(pl => pl.Songs).WithMany(s => s.Playlists);
        #endregion

        #region DefaultInclude

        modelBuilder.Entity<Artist>().Navigation(ar => ar.Albums).AutoInclude();
        modelBuilder.Entity<Artist>().Navigation(ar => ar.Songs).AutoInclude();
        modelBuilder.Entity<Album>().Navigation(al => al.Songs).AutoInclude();
        modelBuilder.Entity<Genre>().Navigation(g => g.Songs).AutoInclude();
        
        #endregion
        #region Default_data
        var genres = new[]
        {
            new Genre { Id = "Поп" },
            new Genre { Id = "Рок" },
            new Genre { Id = "Джаз" },
            new Genre { Id = "Классика" },
            new Genre { Id ="Хип-хоп" },
            new Genre { Id = "Электронная" },
            new Genre { Id ="Блюз" },
            new Genre { Id ="Кантри" },
            new Genre { Id ="Регги" },
            new Genre { Id ="Фолк" },
            new Genre { Id ="Ритм-н-блюз" },
            new Genre { Id ="Метал" },
            new Genre { Id ="Панк" },
            new Genre { Id ="Соул" },
            new Genre { Id ="Диско" }
        };

        modelBuilder.Entity<Genre>().HasData(genres);
        #endregion
    }


    public Context(DbContextOptions<Context> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}