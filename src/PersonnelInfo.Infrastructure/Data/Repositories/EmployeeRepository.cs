using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application;
using PersonnelInfo.Application.DTOs.Entities.Employee;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    EmployeeDto dto;                                // change the complete dto
    Employee addEntity;                             // change entity
    readonly DbSet<Employee> _dbSet;                // change entity
    readonly Type _entityType = typeof(Employee);     // change entity
    readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();          // change entity

        //----------------------------------------------------------------------------------------------------------
        dto = new();
        addEntity = new();
    }


    public async Task<bool> AddAsync(object addDto)
    {
        addEntity = new();
        Mapper.MapToEntity(addDto, addEntity);

        await _dbSet.AddAsync(addEntity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(_entityType);
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }


    public async Task<List<object>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();

        var dtos = new List<object>();

        foreach (var entity in entities)
        {
            dto = new();
            Mapper.MapToDto(entity, dto);
            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<object> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(_entityType);
        dto = new();
        Mapper.MapToDto(entity, dto);
        return dto;
    }

    public async Task<bool> UpdateAsync(object dto)
    {
        var idProperty = dto.GetType().GetProperty("Id") ?? throw new NullReferenceException($"{dto.GetType().Name} does not have id property");
        var idValue = idProperty.GetValue(dto) ?? throw new NullReferenceException("Id cannot be null");
        var entity = await _dbSet.FindAsync(idValue) ?? throw new NotFoundEntity(_entityType);
        Mapper.MapToEntity(dto, entity);
        _dbSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
