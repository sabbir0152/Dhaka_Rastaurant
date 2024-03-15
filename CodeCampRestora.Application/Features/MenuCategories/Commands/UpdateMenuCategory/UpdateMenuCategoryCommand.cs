using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
public record UpdateMenuCategoryCommand(
    Guid Id,
    string Name,
    int DisplayOrder,
    ImageRequestDto? Image,
    Guid? RestaurantId 
) : ICommand<IResult>;