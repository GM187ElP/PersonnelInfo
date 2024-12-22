namespace PersonnelInfo.Core.Entities;

public class JobTitle
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DepartmentId { get; set; }  //nullable
    public ICollection<Person> PersonList { get; set; }
}