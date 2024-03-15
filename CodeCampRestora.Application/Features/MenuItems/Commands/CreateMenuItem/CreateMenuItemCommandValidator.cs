using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public class CreateMenuItemCommandValidator : ApplicationValidator<CreateMenuItemCommand>
    {
        public CreateMenuItemCommandValidator()
        {
            RuleFor(item => item.Price)
            .NotNull().WithMessage("Price can not be null!");
            RuleFor(item => item.CategoryId).
            NotNull().WithMessage("CategoryId can not be null!");
            RuleFor(item => item.BranchId)
            .NotNull().WithMessage("BranchId can not be null!");
            RuleFor(item => item.Image.Type)
            .NotEmpty().WithMessage("Image type is required!")
            .NotNull().WithMessage("Image type can not be null!");
            RuleFor(item => item.Image.Base64)
            .NotEmpty().WithMessage("Base64 is required!");
        }
    }
}