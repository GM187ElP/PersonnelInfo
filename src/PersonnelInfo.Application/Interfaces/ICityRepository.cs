
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Application.Interfaces;
public interface ICityRepository
{
    Task AddAsync(City entity);
    Task DeleteByIdAsync(long id);
    Task UpdateAsync(City entity);
    Task<List<City>> GetAllAsync();
    Task<City> GetByIdAsync(long id);
}
