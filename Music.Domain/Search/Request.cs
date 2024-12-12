using Music.Domain;

namespace Music.Domain.Search;

public class Request
{
    public string? SearchText;  //Поиск по названию альбома, песни или текстовой инф-е исполнителя
                        //Зависит от того определены ли следующие данные
    public string? Genre;    //Поиск по жанру песни
    public int? ArtistId;   //Поиск у конкретного исполнителя
    public int? PlaylistId;    //Поиск в конкретном альбоме
}