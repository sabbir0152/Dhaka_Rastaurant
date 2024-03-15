using System.ComponentModel.DataAnnotations;
using CodeCampRestora.Domain.Identity;

namespace CodeCampRestora.Domain.Entities;

public class Staff
{
    [Key]
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid ApplicationUserId { get; set; } = default!;
    public virtual ApplicationUser? ApplicationUser { get; set; }
}