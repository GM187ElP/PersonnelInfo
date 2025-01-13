using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class JobTitleConfig : IEntityTypeConfiguration<JobTitle>
{
    void IEntityTypeConfiguration<JobTitle>.Configure(EntityTypeBuilder<JobTitle> builder)
    {
        builder.Property(e => e.Title).HasMaxLength(21).IsRequired();
        builder.HasOne(e=>e.Department).WithMany(e=>e.JobTitles).HasForeignKey(e=>e.DepartmentId);
    }
}

