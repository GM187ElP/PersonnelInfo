using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System.Runtime.InteropServices;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class CityRepository : ICityRepository
{
    readonly DbSet<City> _dbSet;
    readonly DbContext _context;

    public CityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<City>();
    }

    public async Task AddAsync(City entity) => await _dbSet.AddAsync(entity);

    public async Task DeleteByIdAsync(long id) => _dbSet.Remove(await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(typeof(City)));


    public async Task<List<City>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        if (!entities.Any()) throw new NotFoundEntity(typeof(City));
        return entities;
    }

    public async Task<City> GetByIdAsync(long id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id) ?? throw new NotFoundEntity(typeof(City));

    public async Task UpdateAsync(City entity) => _context.Entry(await _dbSet.FindAsync(entity.Id) ?? throw new NotFoundEntity(typeof(City))).CurrentValues.SetValues(entity);
}
