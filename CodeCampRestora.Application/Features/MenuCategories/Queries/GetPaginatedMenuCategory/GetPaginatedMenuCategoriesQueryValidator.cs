using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;
public class GetPaginatedMenuCategoriesQueryValidator : ApplicationValidator<GetPaginatedMenuCategoriesQuery>
{
    public GetPaginatedMenuCategoriesQueryValidator()
    {
        RuleFor(item => item.PageNumber)
        .NotNull().WithMessage("PageNumber can not be null!")
        .NotEmpty().WithMessage("PageNumber is required!");

        RuleFor(item => item.PageNumber)
        .NotNull().WithMessage("PageNumber can not be null!")
        .NotEmpty().WithMessage("PageSize is required!");

        RuleFor(item => item.RestaurantId)
        .NotNull().WithMessage("Restaurantd can not be null!")
        .NotEmpty().WithMessage("RestaurantId is required!");
    }
}
