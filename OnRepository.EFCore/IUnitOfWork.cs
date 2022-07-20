namespace OnRepository.EFCore;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IDbContextTransaction? GetCurrentTransaction();
    bool HasActiveTransaction();
    Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction?> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

}
