using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Shared.Enums;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration;
public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasIndex(e=>e.PersonnelCode);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(21);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(21);

        builder.Property(e => e.FatherName).HasMaxLength(21);
        builder.Property(e => e.IsMarried).IsRequired()
        builder.Property(e => e.ChildrenCount).IsRequired().hasdefaultvalue
        builder.Property(e => e.ShenasnameNumber).HasMaxLength(10);
        builder.Property(e => e.ShenasnameSerial).HasMaxLength(2);
        builder.Property(e => e.ShenasnameSerie).HasMaxLength(6);
        builder.Property(e => e.NationalId).IsRequired().HasMaxLength(10);
        builder.Property(e => e.InsurranceCode).IsRequired().HasMaxLength(8);
        builder.Property(e => e.InsurranceStatus).IsRequired().HasMaxLength(11);
        builder.Property(e => e.ExtraInsurranceCount).defa

        builder.HasMany(e => e.ChequePromissionaryNotes).WithOne(c => c.Employee).HasForeignKey(c=>c.EmployeeId);
        builder.HasMany(e => e.StartLeftHistories).WithOne(s=>s.Employee).HasForeignKey(s=>s.EmployeeId);
        builder.HasMany(e => e.StartLeftHistories).WithOne(s=>s.Employee).HasForeignKey(s=>s.EmployeeId);
        builder.HasMany(e => e.BankAccounts).WithOne(b=>b.Employee).HasForeignKey(b=>b.EmployeeId);



        builder.Property(e => e.ExtraInsurranceCount).HasMaxLength(2);
        builder.Property(e => e.SupervisorName).HasMaxLength(35);
        builder.Property(e => e.InternalContactNumber).HasMaxLength(3);
        builder.Property(e => e.LandPhoneNumber).HasMaxLength(11);
        builder.Property(e => e.ContactNumber).HasMaxLength(11);
        builder.Property(e => e.PostalCode).HasMaxLength(10);
        builder.Property(e => e.Major).HasMaxLength(21);


    }
}


#region Basic Information
    public int Id { get; set; }
    public int PersonnelCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    #endregion

    #region Gender and Status
    public GenderType GenderDisplay { get; set; }
    public WorkingStatusType WorkingStatusDisplay { get; set; }
    #endregion

    #region Family Information
    public string FatherName { get; set; }
    public bool IsMarried { get; set; }
    public int ChildrenCount { get; set; }
    #endregion

    #region Identity Information
    public string ShenasnameNumber { get; set; }
    public char ShenasnameSerialLetter { get; set; }
    public string ShenasnameSerie { get; set; }
    public string ShenasnameSerial { get; set; }
    public string NationalId { get; set; }
    #endregion

    #region Birth and Place Information
    public DateTime BirthDate { get; set; }
    public int BirthPlaceId { get; set; }
    public City BirthPlace { get; set; }
    #endregion

    #region Shenasname Issuance Information
    public int ShenasnameIssuedPlaceId { get; set; }
    public City ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    public string InsurranceCode { get; set; }
    public string InsurranceStatus { get; set; }
    public bool HasInsurance { get; set; }
    public int ExtraInsurranceCount { get; set; }
    #endregion

    #region Employment Information
    public int DepartmentId { get; set; }
    public JobTitle JobTitle { get; set; }
    public EmploymentType EmploymentTypeDisplay { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime LeavingDate { get; set; }
    public string SupervisorName { get; set; }
    #endregion

    #region Contact Information
    public string InternalContactNumber { get; set; }
    public string LandPhoneNumber { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    #endregion

    #region Academic Information
    public string MostRecentDegree { get; set; }
    public string Major { get; set; }
    #endregion
