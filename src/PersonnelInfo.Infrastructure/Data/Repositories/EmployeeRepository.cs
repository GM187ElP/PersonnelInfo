using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DbSet<Employee> _dbSet;
    private readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();
    }

    public async Task AddAsync(Employee entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(Employee));
        _dbSet.Remove(entity);
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        if (!entities.Any()) throw new NotFoundEntity(typeof(Employee));
        return entities;
    }

    public async Task<Employee> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
        ?? throw new NotFoundEntity(typeof(Employee));

    public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken)
                             ?? throw new NotFoundEntity(typeof(Employee));
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }

    public async Task<long> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default) =>
        await _dbSet
            .Where(e => e.PersonnelCode < 20000)
            .DefaultIfEmpty()
            .MaxAsync(e => e!.PersonnelCode, cancellationToken);
}
