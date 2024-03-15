using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.ReviewComments;

public class CreateReviewCommentCommand : ICommand<IResult>
{
    public Guid UserId { get; set; } = default!;
    public Guid ReviewId { get; set; }
    public string CommentText { get; set; } = default!;
}
