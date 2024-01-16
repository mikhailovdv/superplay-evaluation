namespace Play.Core.Domain.Abstract;

public interface IEntity<out TKey>
    where TKey : notnull
{
    TKey Id { get; }
}