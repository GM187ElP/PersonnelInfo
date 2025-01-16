using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Shared.Exceptions.Infrastructure;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class BankNameRepository : IBankNameRepository
{
    private readonly DbSet<BankName> _dbSet;
    private readonly DbContext _context;

    public BankNameRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<BankName>();
    }

    public async Task AddAsync(BankName entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(BankName));
        _dbSet.Remove(entity);
    }

    public async Task<List<BankName>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        if (!entities.Any()) throw new NotFoundEntity(typeof(BankName));
        return entities;
    }

    public async Task<BankName> GetByIdAsync(string id, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Name == id, cancellationToken)
        ?? throw new NotFoundEntity(typeof(BankName));

    public async Task UpdateAsync(BankName entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Name }, cancellationToken)
                             ?? throw new NotFoundEntity(typeof(BankName));
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}
