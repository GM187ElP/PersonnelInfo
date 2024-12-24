


using PersonnelInfo.Shared.Enums;

namespace PersonnelInfo.Core.Entities;

public class Employee
{
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
    public string ShenasnameSerialLetter { get; set; }
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
    public DateTime LeftDate { get; set; }
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

    #region Collection Properties
    public ICollection<ChequePromissionaryNote> ChequePromissionaryNotes { get; set; }
    public ICollection<StartLeaveHistory> StartLeftHistories { get; set; }
    public ICollection<BankAccount> BankAccounts { get; set; }
    #endregion
}
