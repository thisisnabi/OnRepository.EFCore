namespace OnRepository.EFCore;

public interface IReadOnlyRepository<T>
    where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<T>?> ListAsync(CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
        
    Task<List<T>?> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}
