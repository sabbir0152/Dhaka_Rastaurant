
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;

public class Address: AuditableEntity<Guid>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Division { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Thana { get; set; } = default!;
    public string AreaDetails { get; set; } = default!;
    public Guid BranchId { get; set; } = default!;
    public Branch? Branch { get; set; }
}
