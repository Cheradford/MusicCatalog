using System.Linq.Expressions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Music.Domain;
using Music.Infrastructure.Database;

namespace Music.Infrastructure;

public class Repository<T1, T2> : IRepository<T1,T2> where T1 : ObjectId<T2>
{
    private readonly Context context;
    private readonly DbSet<T1> Set;
    
    public Repository(Context context)
    {
        this.context = context;
        this.Set = context.Set<T1>();
        TypeAdapterConfig<T1, T1>.NewConfig().PreserveReference(true).IgnoreNullValues(true).MaxDepth(1);
    }

    public async Task<bool> IsIdAvailableAsync(T2 id)
    {
        return ! await Set.AnyAsync(x => x.Id.Equals(id));
    }
    public async Task<IQueryable<T1>> Get(Func<T1, bool>? predicate = null, params Expression<Func<T1, object>>[] includeProperties)
    {
        if(predicate is null) predicate = t => true;
        var selectedQuery = Set.Where(predicate).AsQueryable();
        if (includeProperties.Length != 0)
        {
            return includeProperties
                .Aggregate(selectedQuery, (current, includeProperty) => current.Include(includeProperty));
        }
        return selectedQuery;
        
    }

    public IQueryable<T1> Get(Func<T1, bool>? predicate = null)
    {
        if(predicate is null) predicate = t => true;
        var selectedQuery = Set.Where(predicate).AsQueryable();
        return selectedQuery;
    }

    public async Task<T1?> GetById(T2? id)
    {
        if (id == null) return null;
        return await Set.FindAsync(id);
    }

    public async Task<T1> Add(T1 entity)
    {
        Set.Add(entity);
        await context.SaveChangesAsync();
        return await Set.FindAsync(entity.Id);
    }

    public async Task AddRange(params T1[] entity)
    {
        Set.AddRange(entity);
        await context.SaveChangesAsync();
    }

    public async Task<T1> Update(T1 entity, Action<T1> updateAction)
    {
        var ent = Set.Attach(entity);
        updateAction(ent.Entity);
        ent.State = EntityState.Modified;
        await context.SaveChangesAsync();
        return ent.Entity;
    }

    public async Task<T1> Update(T2 id, T1 entity)
    {
        var ent = await GetById(id);
        if (ent == null) return null;
        entity.Adapt(ent);
        /*context.Entry(ent).State = EntityState.Modified;*/
        await context.SaveChangesAsync();
        return ent;
    }

    public async Task<T1> Update(T2 id, Action<T1> updateAction)
    {
        var entity = Set.Find(id);
        if (entity == null) return null;
        updateAction(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(T2 id)
    {
        var Ent = Set.Find(id);
        if (Ent == null) return;
        await Delete(Ent);
    }

    public async Task Delete(T1 entity)
    {
        if (entity != null)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
            }

            Set.Remove(entity);
        }

        await context.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}