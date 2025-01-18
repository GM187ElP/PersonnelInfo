using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Employees;

public class EmployeeDto : AddEmployeeDto
{
    [Required]
    public long Id { get; set; }
}

