using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.ReviewComments.CommentHideCommand;

public class CommentHideCommandHandler : ICommandHandler<CommentHideCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CommentHideCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CommentHideCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork
            .Comments.GetByIdAsync(request.Id);

        if (comment == null)
        {
            return Result.Failure(ReviewErrors.NotFound);
        }

        comment.IsCommentHidden = request.IsCommentHidden;
        await _unitOfWork.Comments.UpdateAsync(comment.Id, comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
