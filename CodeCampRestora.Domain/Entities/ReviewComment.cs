using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities;

public class ReviewComment : AuditableEntity<Guid>
{
    public Guid UserId { get; set; } = default!;
    public string CommentText { get; set; } = default!;
    public bool IsCommentHidden { get; set; } = false;
    public Guid ReviewId { get; set; }
    public virtual Review Review { get; set; } = default!;
}
