namespace PersonnelInfo.Core.Interfaces;
public interface IEmployeeRepository
{
    Task<bool> AddAsync(object addDto);
    Task<bool> DeleteByIdAsync(int id);
    Task<bool> UpdateAsync(object updateDto);
    Task<List<object>> GetAllAsync();
    Task<object> GetByIdAsync(int id);
}
