using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateDisplayOrder;

public record UpdateMenuCategoryDisplayOrderCommand : ICommand<IResult>
{
    public List<MenuCategoryDto> MenuCategories { get; set; }
    public UpdateMenuCategoryDisplayOrderCommand(List<MenuCategoryDto> menuCategories)
    {
        MenuCategories = menuCategories;
    }
}
