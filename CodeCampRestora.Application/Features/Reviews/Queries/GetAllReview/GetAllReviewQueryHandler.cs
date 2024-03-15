using Mapster;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;

public class GetAllReviewQueryHandler : IQueryHandler<GetAllReviewQuery, IResult<List<ReviewDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllReviewQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<ReviewDTO>>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
    {
         var reviews = await _unitOfWork.Reviews.Get("ReviewComments", request.PageNumber,request.PageSize);
        var reviewsDto = reviews.Adapt<List<ReviewDTO>>();
        
        return Result<List<ReviewDTO>>.Success(reviewsDto);
    }
}
