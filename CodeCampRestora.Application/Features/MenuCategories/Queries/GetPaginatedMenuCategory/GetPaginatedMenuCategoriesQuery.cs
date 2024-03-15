using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory;

public record GetPaginatedMenuCategoriesQuery : IQuery<IResult<PaginationDto<MenuCategoryDto>>>{
    public Guid RestaurantId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set ;}
    public GetPaginatedMenuCategoriesQuery(Guid restauarantId, int pageNumber, int pageSize)
    {
        RestaurantId = restauarantId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}