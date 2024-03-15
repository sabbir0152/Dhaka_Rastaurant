using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.PutDisplayOrder;

public record UpdateMenuItemDisplayOrderCommnad : ICommand<IResult>
{
    public List<MenuItemDto> MenuItems { get; set; }
    public UpdateMenuItemDisplayOrderCommnad(List<MenuItemDto> menuItems)
    {
        MenuItems = menuItems;
    }
}
