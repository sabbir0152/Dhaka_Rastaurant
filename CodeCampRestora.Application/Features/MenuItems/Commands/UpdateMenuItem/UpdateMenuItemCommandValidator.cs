using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
using FluentValidation;


namespace CodeCampRestora.Application.Features.MenuCategories.Commands.CreateMenuCategory
{
    public class UpdateMenuItemCommandValidator : ApplicationValidator<UpdateMenuItemCommand>
    {
        public UpdateMenuItemCommandValidator()
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
            RuleFor(item => item.Id).NotNull().WithMessage("Id can not be null!");
        }
    }
}