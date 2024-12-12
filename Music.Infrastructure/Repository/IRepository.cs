using System.Linq.Expressions;

namespace Music.Infrastructure;

public interface IRepository<T1,T2> where T1:class
{
    public Task<bool> IsIdAvailableAsync(T2 id);
    Task<IQueryable<T1>> Get(Func<T1, bool>? predicate = null, params Expression<Func<T1, object>>[] includeProperties);
    IQueryable<T1> Get(Func<T1, bool>? predicate = null);
    Task<T1?> GetById(T2? id);
    Task<T1> Add(T1 entity);
    Task AddRange(params T1[] entities);
    Task<T1> Update(T1 entity, Action<T1> updateAction);
    Task<T1> Update(T2 id, T1 entity);
    Task<T1> Update(T2 id, Action<T1> updateAction);
    Task Delete(T2 id);
    Task Delete(T1 entity);
    Task SaveChangesAsync();
    

}