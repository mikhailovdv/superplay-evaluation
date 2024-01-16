using Play.Core.Domain;

namespace Play.Core;

public interface IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : notnull
{
    List<TEntity> List();
    
    TEntity? Find(TKey id);
    
    TEntity Add(TEntity entity);
    
    TEntity Update(TEntity entity);
    
    void Delete(TEntity entity);
}