
namespace PersonnelInfo.Core.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProvinceId { get; set; } //nullable
    public ICollection<Person> BirthPlaces { get; set; }
    public ICollection<Person> ShenasnameIssuedPlaces { get; set; }
}
