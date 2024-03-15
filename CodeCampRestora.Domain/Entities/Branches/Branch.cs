using CodeCampRestora.Domain.Enums;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;

public class Branch : AuditableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public PriceRange? PriceRange { get; set; }
    public bool IsAvailable { get; set; }
    public string? ImagePath { get; set; }
    public Guid RestaurantId { get; set; }
    public Address? Address { get; set; }
    public IList<CuisineType>? CuisineTypes { get; set; }
    public IList<OpeningClosingTime>? OpeningClosingTimes { get; set; }
}