
namespace PersonnelInfo.Core.Entities;

public class BankAccount
{
    public int Id { get; set; }
    public string BankName { get; set; }
    public bool IsMain { get; set; }
    public int PersonId { get; set; }
    public string Iban { get; set; }
    public Employee Person { get; set; }
}
