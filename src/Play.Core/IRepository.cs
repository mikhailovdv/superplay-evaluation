using Play.Core.Domain.Abstract;

namespace Play.Core;

public interface IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : notnull
{
    void Init(Dictionary<TKey, TEntity> entities);
    
    List<TEntity> List();
    
    TEntity? Find(TKey id);
    
    TEntity Add(TEntity entity);
    
    TEntity Update(TEntity entity);
    
    void Delete(TEntity entity);
}