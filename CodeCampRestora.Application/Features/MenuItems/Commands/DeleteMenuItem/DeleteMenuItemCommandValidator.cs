using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem;

public class DeleteMenuItemCommandValidator : ApplicationValidator<DeleteMenuItemCommand>
{
    public DeleteMenuItemCommandValidator()
    {
        RuleFor(item => item.Id)
        .NotEmpty().WithMessage("Id is required!")
        .NotNull().WithMessage("Id can not be null");
    }
}
