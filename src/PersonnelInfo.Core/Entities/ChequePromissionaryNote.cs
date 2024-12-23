

using PersonnelInfo.Shared.Enums;

namespace PersonnelInfo.Core.Entities;

public class ChequePromissionaryNote
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public NoteType Type { get; set; }
    public long Amount { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
