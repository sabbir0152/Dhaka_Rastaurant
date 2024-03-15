using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;

namespace CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandHandler : ICommandHandler<CreateReviewCommand, IResult<ReviewDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<ReviewDTO>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var ReviewEO = request.Adapt<Domain.Entities.Review>();

        await _unitOfWork.Reviews.AddAsync(ReviewEO);
        await _unitOfWork.SaveChangesAsync();

        var reviewOrderDto = ReviewEO.Adapt<ReviewDTO>();
        return Result<ReviewDTO>.Success(reviewOrderDto);

    }
}
