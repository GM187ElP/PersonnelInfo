using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System.Runtime.InteropServices;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class CityRepository<T> : IRepository<T> where T :Employee  // change entity
{
    T? _entity;
    readonly DbSet<T> _dbSet;             
    readonly Type _entityType;    
    readonly DbContext _context;

    public CityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();         
        _entityType = typeof(T);
    }
    private T CreateInstance()
    {
        return Activator.CreateInstance<T>();
    }
    public async Task AddAsync(T entity)
    {
        _entity = CreateInstance();
        await _dbSet.AddAsync(_entity);
    }

    public void DeleteById(long id)
    {
        _entity = CreateInstance();
        _dbSet.Remove(_entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<T> GetByIdAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(_entityType);
        return entity;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
