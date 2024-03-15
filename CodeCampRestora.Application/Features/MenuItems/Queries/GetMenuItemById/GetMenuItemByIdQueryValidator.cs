using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetMenuItemById;

public class GetMenuItemByIdQueryValidator : ApplicationValidator<GetMenuItemByIdQuery>
{
    public GetMenuItemByIdQueryValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("Id is required!")
        .NotNull().WithMessage("Id can not be null!");
    }
}
