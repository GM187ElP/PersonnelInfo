using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.Application.Services
{
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
            var entity = Mapper.MapToEntity(addDto, new Employee());
            await _repository.AddAsync(entity);
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            await _repository.DeleteByIdAsync(id);
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var entityList = await _repository.GetAllAsync();
            List<EmployeeDto> employeeDtos = new();
            foreach (var item in entityList)
            {
                employeeDtos.Add(Mapper.MapToDto(item, new EmployeeDto()));
            }
            return employeeDtos;
        }

        public async Task<EmployeeDto> GetByIdAsync(long id)
        {
            var entity = (Employee)await _repository.GetByIdAsync(id);
            return Mapper.MapToDto(entity, new EmployeeDto()) ?? throw new Exception();
        }

        public async Task UpdateAsync(EmployeeDto updateDto)
        {
            var entity = Mapper.MapToEntity(updateDto, new Employee());
            await _repository.Update(entity);
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
