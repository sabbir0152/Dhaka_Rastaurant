using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetAllMenuItems;

public class GetAllMenuItemsQueryValidator : ApplicationValidator<GetAllMenuItemsQuery>
{
    public GetAllMenuItemsQueryValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("BranchId is required!")
        .NotNull().WithMessage("BranchId can not be null!");
    }
}
