
using System.Windows;
using Music.Infrastructure.Service;
using Music.View.Frames;

public abstract class BaseEntityManager<T> where T : class
{
    private Service Service;
    private OperationType Type;
    private T Entity;

    public BaseEntityManager(Service service, OperationType type, T? ent = null)
    {
        Service = service;
        Type = type;
        Entity = ent ?? Activator.CreateInstance<T>();
    }
    
    public abstract class Create(Object sender, RoutedEventArgs e);
    public abstract class Read(Object sender, RoutedEventArgs e);
    public abstract class Update(Object sender, RoutedEventArgs e);
    public abstract class Delete(Object sender, RoutedEventArgs e);
}
