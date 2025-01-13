using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Shared.Enums;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasIndex(e => e.PersonnelCode).IsUnique();
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(21);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(21);
        builder.Property(e => e.FatherName).HasMaxLength(21);
        builder.Property(e => e.NationalId).IsRequired().HasMaxLength(10);
        builder.Property(e => e.ShenasnameNumber).HasMaxLength(10);
        builder.Property(e => e.ShenasnameSerial).HasMaxLength(2);
        builder.Property(e => e.ShenasnameSerie).HasMaxLength(6);
        builder.Property(e => e.ShenasnameSerialLetter).HasMaxLength(3);
        builder.Property(e => e.InsurranceCode).IsRequired().HasMaxLength(8);
        builder.Property(e => e.InsurranceStatus).IsRequired().HasMaxLength(21);
        builder.Property(e => e.InternalContactNumber).HasMaxLength(3);
        builder.Property(e => e.LandPhoneNumber).HasMaxLength(11);
        builder.Property(e => e.ContactNumber).HasMaxLength(11);
        builder.Property(e => e.PostalCode).HasMaxLength(10);
        builder.Property(e => e.MostRecentDegree).HasMaxLength(21);
        builder.Property(e => e.Major).HasMaxLength(21);

        builder.HasOne(e => e.SuperVisor).WithMany(e => e.Employees).HasForeignKey(e => e.SupervisorId);

        builder.HasMany(e => e.ChequePromissionaryNotes).WithOne(c => c.Employee).HasForeignKey(c => c.EmployeeId);
        builder.HasMany(e => e.StartLeftHistories).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeId);
        builder.HasMany(e => e.BankAccounts).WithOne(b => b.Employee).HasForeignKey(b => b.EmployeeId);
    }
}

