using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using System.Runtime.InteropServices;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    readonly DbSet<Employee> _dbSet;
    readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();
    }

    public async Task AddAsync(Employee entity) => await _dbSet.AddAsync(entity);

    public async Task DeleteByIdAsync(long id) => _dbSet.Remove(await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(typeof(Employee)));


    public async Task<List<Employee>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        if (!entities.Any()) throw new NotFoundEntity(typeof(Employee));
        return entities;
    }

    public async Task<Employee> GetByIdAsync(long id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id) ?? throw new NotFoundEntity(typeof(Employee));

    public async Task UpdateAsync(Employee entity) => _context.Entry(await _dbSet.FindAsync(entity.Id) ?? throw new NotFoundEntity(typeof(Employee))).CurrentValues.SetValues(entity);
}
