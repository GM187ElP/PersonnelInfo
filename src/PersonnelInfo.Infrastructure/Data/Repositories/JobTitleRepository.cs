using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System.Runtime.InteropServices;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class JobTitleRepository : IJobTitleRepository
{
    readonly DbSet<JobTitle> _dbSet;
    readonly DbContext _context;

    public JobTitleRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<JobTitle>();
    }

    public async Task AddAsync(JobTitle entity) => await _dbSet.AddAsync(entity);

    public async Task DeleteByIdAsync(string id) => _dbSet.Remove(await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(typeof(JobTitle)));


    public async Task<List<JobTitle>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        if (!entities.Any()) throw new NotFoundEntity(typeof(JobTitle));
        return entities;
    }

    public async Task<JobTitle> GetByIdAsync(string id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Title == id) ?? throw new NotFoundEntity(typeof(JobTitle));

    public async Task UpdateAsync(JobTitle entity) => _context.Entry(await _dbSet.FindAsync(entity.Title) ?? throw new NotFoundEntity(typeof(JobTitle))).CurrentValues.SetValues(entity);
}
