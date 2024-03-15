using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
public class DeleteMenuCategoryCommandValidator : ApplicationValidator<DeleteMenuCategoryCommand>
{
    public DeleteMenuCategoryCommandValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("Id is required!")
        .NotNull().WithMessage("Id can not be null!");
    }
}