using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using FluentValidation;

namespace CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandValidator: ApplicationValidator<CreateReviewCommand>
{

    public CreateReviewCommandValidator()
    {
        RuleFor(order => order.OrderId).NotNull().WithMessage("OrderId can not be null");
        RuleFor(branch => branch.BranchId).NotNull().WithMessage("BranchId can not be null");
        RuleFor(description => description.Description).NotNull().WithMessage("Description can not be null");
        RuleFor(rating => rating.Rating).NotNull().WithMessage("Rating can not be null");

    }

}
