
namespace PersonnelInfo.Core.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProvinceId { get; set; } //nullable
    public ICollection<Employee> BirthPlaces { get; set; }
    public ICollection<Employee> ShenasnameIssuedPlaces { get; set; }
}
