using System.Data;
using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetAllMenuCategory;

public class GetAllMenuCategoryQueryValidator : ApplicationValidator<GetAllMenuCategoryQuery>
{
    public GetAllMenuCategoryQueryValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("RestaurantId is required!")
        .NotNull().WithMessage("RestaurantId can not be null!");
    }
}
