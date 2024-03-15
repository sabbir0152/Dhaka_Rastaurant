using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;

public record GetAllReviewQuery : IQuery<IResult<List<ReviewDTO>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetAllReviewQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
