using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommand : ICommand<IResult<ReviewDTO>>
{
  
    public Guid BranchId { set; get; }
    public Guid OrderId { set; get; }
    public  string? Description { set; get; }
    public  double Rating { set; get; }
    
}
