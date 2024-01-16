using Play.Core.Domain.Abstract;
using Play.Core.Error;

namespace Play.Core;

public record PlayServiceResult<TDomain, TKey, TError>(
    TDomain? Content, TError? Error)
    where TDomain : IEntity<TKey>
    where TKey : notnull
    where TError : IPlayServiceError;