using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class CityRepository /*: ICityRepository*/
{
    private readonly DbSet<City> _dbSet;
    private readonly DbContext _context;

    public CityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<City>();
    }

    //public async Task<Dictionary<string,string>> GetAllAsync(CancellationToken cancellationToken = default)
    //{
    //    return await _dbSet.AsNoTracking()
    //    .Where(c => c.ProvinceId != null) // Get only cities
    //    .GroupBy(c => c.ProvinceId) // Group by ProvinceId
    //    .Select(g => new
    //    {
    //        Province = _dbSet.First(p => p.Id == g.Key).Name, // Get province name
    //        Cities = g.Select(c => c.Name).ToList() // Get city names
    //    })
    //    .ToDictionaryAsync(g => g.Province, g => g.Cities, cancellationToken);

    //    return entities;
    //}

    public async Task<City> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}
