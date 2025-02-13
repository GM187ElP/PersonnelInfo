﻿namespace PersonnelInfo.Core.Entities;

public class StartLeaveHistory
{
    public long Id { get; set; }
    public DateTime? StartedDate { get; set; }
    public DateTime? LeftDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
