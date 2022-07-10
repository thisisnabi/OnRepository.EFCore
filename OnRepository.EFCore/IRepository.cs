namespace OnRepository.EFCore;

public interface IRepository<T> : IReadOnlyRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

}

