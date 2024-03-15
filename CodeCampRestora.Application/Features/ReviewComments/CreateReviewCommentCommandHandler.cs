using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.ReviewComments;

public class CreateReviewCommentCommandHandler : ICommandHandler<CreateReviewCommentCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(CreateReviewCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = request.Adapt<ReviewComment>();
        await _unitOfWork.Comments.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
