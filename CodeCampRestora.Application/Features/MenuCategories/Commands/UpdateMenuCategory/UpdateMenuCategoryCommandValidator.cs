using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
using FluentValidation;


namespace CodeCampRestora.Application.Features.MenuCategories.Commands.CreateMenuCategory
{
    public class UpdateMenuCategoryCommandValidator : ApplicationValidator<UpdateMenuCategoryCommand>
    {
        public UpdateMenuCategoryCommandValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(item => item.Image).NotNull().WithMessage("Image can not be null!");
            RuleFor(item => item.RestaurantId).NotNull().WithMessage("RestaurantId can not be null!");
            RuleFor(item => item.Id).NotNull().WithMessage("Id can not be null!");
        }
    }
}