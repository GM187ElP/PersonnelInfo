using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    #region Basic Information
    [Required]
    public int PersonnelCode { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string NationalId { get; set; }
    [Required]
    public string ContactNumber { get; set; }
    #endregion

    #region Gender and Status
    public GenderType? GenderDisplay { get; set; }
    public WorkingStatusType? WorkingStatusDisplay { get; set; }
    #endregion

    #region Family Information
    public string FatherName { get; set; }
    public bool? IsMarried { get; set; }
    public int? ChildrenCount { get; set; }
    #endregion

    #region Identity Information
    public string ShenasnameNumber { get; set; }
    public string ShenasnameSerialLetter { get; set; }
    public string ShenasnameSerie { get; set; }
    public string ShenasnameSerial { get; set; }
    #endregion

    #region Birth and Place Information
    public DateTime? BirthDate { get; set; }
    public int? BirthPlaceId { get; set; }
    #endregion

    #region Shenasname Issuance Information
    public int? ShenasnameIssuedPlaceId { get; set; }
    #endregion

    #region Insurance Information
    public string InsurranceCode { get; set; }
    public string InsurranceStatus { get; set; }
    public bool? HasInsurance { get; set; }
    public int? ExtraInsurranceCount { get; set; }
    #endregion

    #region Employment Information
    public int? DepartmentId { get; set; }
    public EmploymentType? EmploymentTypeDisplay { get; set; }
    public DateTime LeftDate { get; set; }
    public string SupervisorName { get; set; }
    #endregion

    #region Contact Information
    public string? InternalContactNumber { get; set; }
    public string? LandPhoneNumber { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    #endregion

    #region Academic Information
    public string MostRecentDegree { get; set; }
    public string Major { get; set; }
    #endregion
}
