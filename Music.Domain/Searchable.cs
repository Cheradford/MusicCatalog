using Music.Domain.Search;

namespace Music.Domain;

public abstract class Searchable<T> : ObjectId<T>, ISearchable
{
    public virtual bool Preproccess(Request searchTerm) => true;
    
    public abstract string GetTarget();
}