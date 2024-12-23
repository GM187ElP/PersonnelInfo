using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application;
using PersonnelInfo.Application.DTOs.Entities.Person;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System.Collections.Generic;

namespace PersonnelInfo.Infrastructure.Data;
public class PersonRepository : IPersonRepository
{
    
    readonly Type _entityType= typeof(Person);
    readonly PersonnelInfoDbContext _context;
    readonly DbSet<T> _dbSet;

    public PersonRepository(PersonnelInfoDbContext context)
    {
        _context = context;
        var method = _context.GetType().GetMethod("Set");
        var genericMethod = method.MakeGenericMethod(_entityType); // Making Set<T> generic
        _dbSet = genericMethod.Invoke(_context, null);
    }

    public async Task AddAsync(AddPersonDto addPersonDto)
    {
        var entity = Activator.CreateInstance<T>();
        MapperToEntity.MapToEntity(addPersonDto,entity);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await GetEntityByIdAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PersonDto>> GetAllAsync()
    {
        var persons = await _dbSet.ToListAsync();  
        var personDtos = persons.Select(p =>
        {
            var dto = new PersonDto();
            MapperToDto.MapToDto(p, dto);  
            return dto;
        }).ToList();

        return personDtos;
    }

    public async Task<PersonDto> GetDtoByIdAsync(int id)
    {
        var person= await _dbSet.FindAsync(id);
        var personDto= new PersonDto();
        if (person == null)
        {
            throw new NotFoundEntity(typeof(Person));
        }
        MapperToDto.MapToDto(person, personDto);
        return personDto;
    }

    public async Task<Person> GetEntityByIdAsync(int id)
    {
        var person = await _dbSet.FindAsync(id);
        if (person == null)
        {
            throw new NotFoundEntity(typeof(Person));
        }
        
        return person;
    }

    public async Task<bool> UpdateAsync(UpdatePersonDto updatePersonDto)
    {
        var person = new Person();
        MapperToEntity.MapToEntity(updatePersonDto, person);
        await _dbSet.AddAsync(person);
        var done=await _context.SaveChangesAsync();
        return done > 0;
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