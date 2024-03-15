using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetCategoryById;
public class GetMenuCategoryByIdQueryValidator : ApplicationValidator<GetMenuCategoryByIdQuery>
{
    public GetMenuCategoryByIdQueryValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("Id is required!")
        .NotNull().WithMessage("Id can not be null!");
    }
}
