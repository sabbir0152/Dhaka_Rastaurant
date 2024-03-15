using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetAllMenuItems;
public class GetAllMenuItemsQueryCommand : IQueryHandler<GetAllMenuItemsQuery, IResult<List<MenuItemDto>>>
{   
    private readonly IMenuItemService _menuItemService;
    public GetAllMenuItemsQueryCommand(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }
    public Task<IResult<List<MenuItemDto>>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var result = _menuItemService.GetAllMenuItemsAsync(request.Id);
        return result;
    }
}
