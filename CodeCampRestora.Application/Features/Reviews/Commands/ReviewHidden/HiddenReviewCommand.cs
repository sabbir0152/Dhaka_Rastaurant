using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Commands.IsReviewHidden;

public class HiddenReviewCommand : ICommand<IResult>
{
    public Guid Id { get; set; }
    public bool IsReviewHidden { get; set; }

}
