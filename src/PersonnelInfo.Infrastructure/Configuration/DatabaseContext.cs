using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration;
public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);
    }
}
