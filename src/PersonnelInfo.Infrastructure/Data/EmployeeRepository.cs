using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application;
using PersonnelInfo.Application.DTOs.Entities.Person;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

namespace PersonnelInfo.Infrastructure.Data;
public class EmployeeRepository<T> : IRepository  where T : class
{
    readonly Type _entityType;
    readonly Type _dto;
    readonly Type _addDto;
    readonly Type _updateDto;
    readonly DbContext _context;
    readonly DbSet<T> _dbSet;

    public EmployeeRepository(DbContext context)
    {
        _entityType = typeof(T);
        
        _dto = TypeFinder.FindDtoType(_entityType.Name)
                ?? throw new InvalidOperationException($"DTO type {_entityType.Name} not found.");
        _addDto = TypeFinder.FindDtoType(_entityType.Name, "Add")
                ?? throw new InvalidOperationException($"Add DTO type {_entityType.Name} not found.");
        _updateDto = TypeFinder.FindDtoType(_entityType.Name, "Update")
                ?? throw new InvalidOperationException($"Update DTO type {_entityType.Name} not found.");

        _context = context;

        _dbSet = _context.Set<T>() ?? throw new InvalidOperationException($"DbSet for {_entityType.Name} not found.");
    }
    public async Task AddAsync(object addDto)
    {
        var entity = Activator.CreateInstance(_entityType);

        if (entity == null)
            throw new InvalidOperationException($"Unable to create an instance of type {_entityType.Name}.");
      
        Mapper.MapToEntity(addDto, entity);

        var ResolvedEntity=(T)Convert.ChangeType(entity, typeof(T));
        await _dbSet.AddAsync(ResolvedEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var entity = await GetEntityByIdAsync(id);
        _dbSet.Remove(entity);
        var operationResult= await _context.SaveChangesAsync();
        return operationResult>0;
    }


    public async Task<List<object>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        var dtos = new List<object>();

        foreach (var entity in entities)
        {
            var dto = Activator.CreateInstance(_dto); 
            var mapMethod = typeof(Mapper)
                            .GetMethod("MapToDto", new[] { _entityType, _dto }); 

            if (mapMethod != null)
            {
                mapMethod.Invoke(null, new object[] { entity, dto });
            }

            dtos.Add(dto); 
        }

        return dtos;
    }

    public async Task<object> GetDtoByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new NotFoundEntity(_entityType);
        }
        var dto = Activator.CreateInstance(_dto);

        Mapper.MapToDto(entity, dto);
        return dto;
    }

    public async Task<T> GetEntityByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new NotFoundEntity(_entityType);
        }
        return (T)Convert.ChangeType(entity, typeof(T)); 
    }

    public async Task<bool> UpdateAsync(object updateDto)
    {
        Convert.ChangeType(updateDto, _updateDto);
        var entity = await _dbSet.FindAsync(updateDto.GetType().GetProperty("Id"));
        Mapper.MapToEntity(updateDto, entity);
          _dbSet.Update(entity);
        return  await _context.SaveChangesAsync()>0;
    }
}

[Serializable]
public class NotFoundEntity : Exception
{
    private Type type;

    public NotFoundEntity()
    {
    }

    public NotFoundEntity(Type type)
    {
        this.type = type;
        Console.WriteLine("Nothing is found!");
    }

    public NotFoundEntity(string? message) : base(message)
    {
    }

    public NotFoundEntity(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}