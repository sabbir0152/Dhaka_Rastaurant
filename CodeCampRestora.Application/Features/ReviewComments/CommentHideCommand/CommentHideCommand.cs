using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.ReviewComments.CommentHideCommand;

public class CommentHideCommand : ICommand<IResult>
{
    public Guid Id { get; set; }
    public bool IsCommentHidden { get; set; }
}
