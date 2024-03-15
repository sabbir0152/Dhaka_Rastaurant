using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;
public class GetPaginatedMenuItemsQueryValidator : ApplicationValidator<GetPaginatedMenuItemsQuery>
{
    public GetPaginatedMenuItemsQueryValidator()
    {
        RuleFor(item => item.PageNumber)
        .NotNull().WithMessage("PageNumber can not be null!")
        .NotEmpty().WithMessage("PageNumber is required!");

        RuleFor(item => item.PageNumber)
        .NotNull().WithMessage("PageNumber can not be null!")
        .NotEmpty().WithMessage("PageSize is required!");

        RuleFor(item => item.BranchId)
        .NotNull().WithMessage("BranchId can not be null!")
        .NotEmpty().WithMessage("BranchId is required!");
    }
}
