using System.ComponentModel.DataAnnotations;

namespace Music.Domain;

public class ObjectId<T>
{
    [Key] public T Id { get; set; }
}