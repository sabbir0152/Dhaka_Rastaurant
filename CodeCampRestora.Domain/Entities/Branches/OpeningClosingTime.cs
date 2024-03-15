using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;

public class OpeningClosingTime:AuditableEntity<Guid>
{
    public DayOfWeek Day { get; set; }
    public TimeOnly OpeningHours { get; set; }
    public TimeOnly ClosingHours { get; set; }
    public bool IsClosed { get; set; }
    public Guid BranchId { get; set; }
}
