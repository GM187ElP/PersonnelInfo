using PersonnelInfo.Application.DTOs.Entities.Employee;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeServices(IEmployeeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task AddAsync(AddEmployeeDto addDto, CancellationToken cancellationToken = default)
    {
        var _entity = new Employee();
        _entity = Mapper.MapToEntity(addDto, _entity);
        _entity.PersonnelCode = await _repository.MaxPersonnelCodeAsync(cancellationToken) + 1;

        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.AddAsync(_entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.DeleteByIdAsync(id, cancellationToken);
        }, cancellationToken);
    }

    public async Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);
        var employeesDto = new List<EmployeeDto>();
        entityList.ForEach(e => employeesDto.Add(Mapper.MapToDto(e, new EmployeeDto())));
        return employeesDto;
    }

    public async Task<EmployeeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default)
    {
        var entity = Mapper.MapToEntity(updateDto, new Employee());

        await _unitOfWork.ExecuteInTransactionAsync(async (tc) =>
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }, cancellationToken);
    }
}
