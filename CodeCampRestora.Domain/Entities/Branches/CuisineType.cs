using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;


public class CuisineType: AuditableEntity<Guid>
{
    public string CuisineTag { get; set; } = default!;
    public Guid BranchId { get; set; }

}
