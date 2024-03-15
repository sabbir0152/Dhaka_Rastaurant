using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;


namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;

public record GetPaginatedMenuItemsQuery : IQuery<IResult<PaginationDto<MenuItemDto>>>
{
    public Guid BranchId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetPaginatedMenuItemsQuery(Guid branchId, int pageNumber, int pageSize)
    {
        BranchId = branchId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

