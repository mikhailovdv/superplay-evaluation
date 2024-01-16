using System.Collections.Concurrent;
using Play.Core;
using Play.Core.Domain;
using Play.Core.Domain.Abstract;

namespace Play.Persistence;

public class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, TEntity> _entities
        = new();
    public List<TEntity> List()
    {
        return _entities.Values.ToList();
    }

    public TEntity? Find(TKey id)
    {
        _entities.TryGetValue(id, out var entity);
        return entity;
    }

    public TEntity Add(TEntity entity)
    {
        if(!_entities.TryAdd(entity.Id, entity))
        {
            throw new ArgumentException(
                $"An entity with the same key ({entity.Id}) already exists");
        }

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        if (_entities.TryGetValue(entity.Id, out var existingEntity))
        {
            _entities.TryUpdate(entity.Id, entity, existingEntity);
            return entity;
        }
        throw new KeyNotFoundException(
            $"No entity found with the key {entity.Id} to update");
    }

    public void Delete(TEntity entity)
    {
        if (!_entities.TryRemove(entity.Id, out _))
        {
            throw new KeyNotFoundException(
                $"No entity found with the key {entity.Id} to delete");
        }
    }
}