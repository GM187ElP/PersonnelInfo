using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PersonnelInfo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Services;
public class UnitOfWork : IUnitOfWork
{
    readonly DbContext _dbContext;
    IDbContextTransaction _currentTransaction;
    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task BeginTransactionAsync()
    {
        _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await _dbContext.SaveChangesAsync();
            await _currentTransaction.CommitAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
