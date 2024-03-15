using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Application.Models;
using Mapster;
using MediatR;

namespace CodeCampRestora.Application.Features.Reviews.Commands.IsReviewHidden;

public class HiddenReviewConmmandHandler : ICommandHandler<HiddenReviewCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public HiddenReviewConmmandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    async Task<IResult> IRequestHandler<HiddenReviewCommand, IResult>.Handle(HiddenReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(request.Id);

        if (review == null)
        {
            throw new ResourceNotFoundException("No review found");
        }

        review.IsReviewHidden = request.IsReviewHidden;
        await _unitOfWork.Reviews.UpdateAsync(request.Id, review);
        await _unitOfWork.SaveChangesAsync();

        var reviewOrderDto = review.Adapt<ReviewDTO>();
        return Result.Success();
    }
}


