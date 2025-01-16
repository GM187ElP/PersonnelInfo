using PersonnelInfo.Core.DTOs.Cities;

namespace PersonnelInfo.Application.Services;

public interface ICityServices
{
    Task AddAsync(AddCityDto addDto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CityDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAsync(CityDto updateDto, CancellationToken cancellationToken = default);
}