﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Interfaces;
public class PersonnelInfoDbContext:DbContext
{
    public PersonnelInfoDbContext(DbContextOptions<PersonnelInfoDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonnelInfoDbContext).Assembly);
    }
}
