
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Application.Interfaces;
public interface IBankNameRepository
{
    Task AddAsync(BankName entity);
    Task DeleteByIdAsync(string id);
    Task UpdateAsync(BankName entity);
    Task<List<BankName>> GetAllAsync();
    Task<BankName> GetByIdAsync(string id);
}
