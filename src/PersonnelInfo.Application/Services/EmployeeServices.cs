using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.DTOs.Employees;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Shared.Exceptions.Infrastructure;

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
        var entity = Mapper.MapToEntity(addDto, new Employee());
        entity.PersonnelCode = await _repository.MaxPersonnelCodeAsync(cancellationToken) + 1;

        await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        {
            await _repository.AddAsync(entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(Employee));

        var relatedEntities = PreChangeProcedures.GetRelatedEntityCounts(entity);
        if (relatedEntities.Any())
        {
            var message = $"Cannot delete employee with related records: " + string.Join(", ", relatedEntities.Select(re => $"{re.Key}: {re.Value}"));
            throw new InvalidOperationException(message);
        }

        await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        {
            await _repository.DeleteAsync(entity, cancellationToken);
        }, cancellationToken);
    }

    public async Task<List<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entityList = await _repository.GetAllAsync(cancellationToken);
        if (!entityList.Any()) throw new NotFoundEntity(typeof(Employee));

        return entityList.Select(e => Mapper.MapToDto(e, new EmployeeDto())).ToList();
    }

    public async Task<EmployeeDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundEntity();

        return Mapper.MapToDto(entity, new EmployeeDto());
    }

    public async Task UpdateAsync(EmployeeDto updateDto, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(updateDto.Id, cancellationToken)
                      ?? throw new NotFoundEntity(typeof(Employee));

        Mapper.MapToEntity(updateDto, entity);

        await _unitOfWork.ExecuteInTransactionAsync(async _ =>
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }, cancellationToken);
    }
}
