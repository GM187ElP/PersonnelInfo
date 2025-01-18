using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using System.Linq;

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

    public async Task DeleteAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        return entities;
    }

    public async Task<Employee> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default) =>
         await _dbSet.FirstOrDefaultAsync(e => e.NationalId == nationalId);

    public async Task<Employee> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }

    public async Task<long> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default)
    {
        // Fetch the records from the database
        var employees = await _dbSet
            .Where(e => e.PersonnelCode < 20000)
            .ToListAsync(cancellationToken); // Load into memory first

        // If there are no employees, use a default value
        var max = employees.DefaultIfEmpty(new Employee { PersonnelCode = 0 })
                           .Max(e => e.PersonnelCode); // Get max from in-memory data

        return max;
    }


}
