
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Application.Interfaces;
public interface IJobTitleRepository
{
    Task AddAsync(JobTitle entity);
    Task DeleteByIdAsync(string id);
    Task UpdateAsync(JobTitle entity);
    Task<List<JobTitle>> GetAllAsync();
    Task<JobTitle> GetByIdAsync(string id);
}
