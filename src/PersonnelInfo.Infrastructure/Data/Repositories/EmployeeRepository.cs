using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    Employee _entity;                             // change entity
    readonly DbSet<Employee> _dbSet;                // change entity
    readonly Type _entityType = typeof(Employee);     // change entity
    readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();          // change entity

        //----------------------------------------------------------------------------------------------------------
        _entity = new();
    }

    public async Task AddAsync(object entity)
    {
        _entity = entity as Employee;
        await _dbSet.AddAsync(_entity);
    }

    public async Task DeleteByIdAsync(long id)
    {
        _entity =await GetByIdAsync(id) as Employee;
        _dbSet.Remove(_entity);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<object> GetByIdAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(_entityType);
        return entity;
    }

    public async Task Update(object entity)
    {
        _dbSet.Update((Employee)entity);
    }
}
