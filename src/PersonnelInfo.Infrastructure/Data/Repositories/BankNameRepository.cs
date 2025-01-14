using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Core.Entities;
using System.Runtime.InteropServices;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class BankNameRepository : IBankNameRepository
{
    readonly DbSet<BankName> _dbSet;
    readonly DbContext _context;

    public BankNameRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<BankName>();
    }

    public async Task AddAsync(BankName entity) => await _dbSet.AddAsync(entity);

    public async Task DeleteByIdAsync(string id) => _dbSet.Remove(await _dbSet.FindAsync(id) ?? throw new NotFoundEntity(typeof(BankName)));


    public async Task<List<BankName>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        if (!entities.Any()) throw new NotFoundEntity(typeof(BankName));
        return entities;
    }

    public async Task<BankName> GetByIdAsync(string id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Name == id) ?? throw new NotFoundEntity(typeof(BankName));

    public async Task UpdateAsync(BankName entity) => _context.Entry(await _dbSet.FindAsync(entity.Name) ?? throw new NotFoundEntity(typeof(BankName))).CurrentValues.SetValues(entity);
}
