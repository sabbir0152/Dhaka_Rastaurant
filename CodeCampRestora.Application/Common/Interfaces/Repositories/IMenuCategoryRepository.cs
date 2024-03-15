using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IMenuCategoryRepository : IRepository<MenuCategory, Guid>
    {
        Task<List<MenuCategory>> GetAllByIdAsync(Guid Id);
        Task<PagedList<MenuCategory>> GetPaginatedByIdAsync(
            Guid Id, 
            int pageNumber, 
            int pageSize
        );
        Task<IResult> UpdateMenuCategoryAsync(List<MenuCategory> newMenuCategories);
        Task<List<MenuCategory>> GetAllHomeMenuCategoryAsync();
    }
}