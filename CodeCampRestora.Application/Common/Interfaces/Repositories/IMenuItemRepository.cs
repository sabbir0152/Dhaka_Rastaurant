using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IMenuItemRepository : IRepository<MenuItem, Guid>
{
    Task<List<MenuItem>> GetAllByIdAsync(Guid Id);
    Task<PagedList<MenuItem>> GetPaginatedByIdAsync(
        Guid Id, 
        int pageNumber, 
        int pageSize
    );
    Task<IResult> UpdateMenuItemsAsync(List<MenuItem> newMenuItems);
}