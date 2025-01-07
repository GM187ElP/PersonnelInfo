namespace PersonnelInfo.Core.Interfaces;
public interface IUnitOfWork : IDisposable
{
    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    //Task SaveAsync(CancellationToken cancellationToken = default);
}
