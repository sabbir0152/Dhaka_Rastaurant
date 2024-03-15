using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.Reviews.Commands.IsReviewHidden;

public class HiddenReviewCommandValidator : ApplicationValidator<HiddenReviewCommand>
{
    public HiddenReviewCommandValidator()
    {
        // RuleFor(hidden => hidden.HideReview).NotEmpty().WithMessage("Review status can't be empty");
    }
}
