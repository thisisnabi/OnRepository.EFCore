namespace OnRepository.EFCore;

public class ReposDbContext : DbContext, IUnitOfWork
{ 
    public ReposDbContext(DbContextOptions<DbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
  

    #region Transactions
    private IDbContextTransaction? _currentTransaction;

    public IDbContextTransaction? GetCurrentTransaction()
        => _currentTransaction;

    public bool HasActiveTransaction
        => _currentTransaction != null;

    private void TransactionDispose()
    {
        if (_currentTransaction != null)
        {
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }
    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

        return _currentTransaction;
    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
    {
        if (_currentTransaction is not null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default)
    {
        if (transaction == null)
        {
            ThrowHelper.ThrowArgumentNullException(nameof(transaction));
        }
        else if (transaction != _currentTransaction)
        {
            ThrowHelper.ThrowInvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        }

        try
        {
            await SaveChangesAsync(cancellationToken);
            if (transaction != null)
            {
                await transaction.CommitAsync(cancellationToken);
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            ThrowHelper.ThrowRollbackTransactionException(transaction?.TransactionId);
        }
        finally
        {
            TransactionDispose();
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
        }
        finally
        {
            TransactionDispose();
        }
    }
    #endregion
}

