using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class CityRepository : ICityRepository
{
    private readonly DbSet<City> _dbSet;
    private readonly DbContext _context;

    public CityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<City>();
    }

    public async Task AddAsync(City entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(City));
        _dbSet.Remove(entity);
    }

    public async Task<List<City>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        if (!entities.Any()) throw new NotFoundEntity(typeof(City));
        return entities;
    }

    public async Task<City> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken)
        ?? throw new NotFoundEntity(typeof(City));

    public async Task UpdateAsync(City entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken)
                             ?? throw new NotFoundEntity(typeof(City));
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}
