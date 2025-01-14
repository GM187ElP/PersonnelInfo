using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        readonly IEmployeeRepository<Employee> _repository;

        readonly IUnitOfWork _unitOfWork;

        public EmployeeServices(IEmployeeRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task AddAsync(AddEmployeeDto addDto)
        {
            var _entity = new Employee();
            _entity = Mapper.MapToEntity(addDto, _entity);

            await _unitOfWork.BeginTransactionAsync();
            await _repository.AddAsync(_entity);
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            await _unitOfWork.BeginTransactionAsync();
            _repository.DeleteById(id);
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var entityList = await _repository.GetAllAsync();
            var employeesDto = new List<EmployeeDto>();
            foreach (var item in entityList)
            {
                employeesDto.Add(Mapper.MapToDto(item, new EmployeeDto()));
            }
            return employeesDto;
        }

        public async Task<EmployeeDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return Mapper.MapToDto(entity, new EmployeeDto()) ?? throw new Exception();
        }

        public async Task UpdateAsync(EmployeeDto updateDto)
        {
            var entity = Mapper.MapToEntity(updateDto, new Employee());

            await _unitOfWork.BeginTransactionAsync();
            _repository.Update(entity);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
