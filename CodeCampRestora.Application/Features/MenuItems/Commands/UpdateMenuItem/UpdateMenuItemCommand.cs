using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
public record UpdateMenuItemCommand(
        Guid Id,
        string Name,
        string Description,
        string Ingredients, 
        double? Price,
        bool Availability,
        ImageRequestDto Image,
        int DisplayOrder, 
        Guid? CategoryId,
        Guid? BranchId
) : ICommand<IResult>;