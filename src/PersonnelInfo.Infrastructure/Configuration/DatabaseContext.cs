using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration;
public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder connectionString = new()
        {
            DataSource = ".",
            InitialCatalog = "PersonnelInfoDb",
            IntegratedSecurity = true,
            MultipleActiveResultSets = true,
            TrustServerCertificate = true,
        };

        optionsBuilder.UseSqlServer(connectionString.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig).Assembly);
    }
}
