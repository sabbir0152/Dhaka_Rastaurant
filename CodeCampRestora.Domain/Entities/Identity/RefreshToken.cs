using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Identity;

public class RefreshToken : BaseEntity<Guid>
{
    public Guid JwtId { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime Expiry { get; init; } = default!;
    public bool Used { get; private set; }
    public Guid ApplicationUserId { get; init; }
    public ApplicationUser ApplicationUser { get; } = default!;

    public void MarkIsUsed(bool isUsed) => Used = isUsed;
}