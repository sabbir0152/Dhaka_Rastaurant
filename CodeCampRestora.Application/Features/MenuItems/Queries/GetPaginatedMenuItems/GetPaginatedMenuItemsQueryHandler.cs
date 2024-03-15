using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;

public class GetPaginatedMenuItemsQueryHandler 
: IQueryHandler<GetPaginatedMenuItemsQuery, IResult<PaginationDto<MenuItemDto>>>
{
    private readonly IMenuItemService _menuItemService;
    public GetPaginatedMenuItemsQueryHandler(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }
    public Task<IResult<PaginationDto<MenuItemDto>>> Handle(GetPaginatedMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var result = _menuItemService
        .GetPaginatedAsync(request.BranchId, request.PageNumber, request.PageSize);

        return result;
    }
}
