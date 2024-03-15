using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory
{
    public record CreateMenuCategoryCommand(
        string Name,
        int DisplayOrder,
        ImageRequestDto? Image,
        Guid? RestaurantId 
    ) : ICommand<IResult<Guid>>;
}