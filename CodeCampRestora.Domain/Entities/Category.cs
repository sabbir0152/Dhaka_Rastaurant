using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Category : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid RestaurantId { get; set; } = default!;
    public Restaurant? Restaurant { get; set; }
}
