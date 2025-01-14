using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Enums;

namespace PersonnelInfo.Application.Services;

public class EmployeeServices : IEmployeeServices
{
    readonly IEmployeeRepository _repository;
    readonly IUnitOfWork _unitOfWork;

    public EmployeeServices(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task AddAsync(AddEmployeeDto addDto)
    {
        var _entity = new Employee();
        _entity = Mapper.MapToEntity(addDto, _entity);
        _entity.PersonnelCode = await _repository.MaxPersonnelCodeAsync() + 1;

        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            await _repository.AddAsync(_entity);
        });
    }

    public async Task DeleteByIdAsync(long id)
    {
        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            await _repository.DeleteByIdAsync(id);
        });
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var entityList = await _repository.GetAllAsync();
        var employeesDto = new List<EmployeeDto>();
        entityList.ForEach(e => employeesDto.Add(Mapper.MapToDto(e, new EmployeeDto())));
        return employeesDto;
    }

    public async Task<EmployeeDto> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task UpdateAsync(EmployeeDto updateDto)
    {
        var entity = Mapper.MapToEntity(updateDto, new Employee());

        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            await _repository.UpdateAsync(entity);
        });
    }
}