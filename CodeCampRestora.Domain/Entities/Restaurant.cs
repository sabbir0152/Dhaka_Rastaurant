using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
    public ApplicationUser? ApplicationUser { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<Branch>? Branches { get; set; }

    public static Restaurant CreateDefaultRestaurant(string? name)=> new()
    {
        Name = string.IsNullOrEmpty(name) ? "Your first restaurant" : name,
        ImagePath = ""
    };
}
