using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services
{
    public interface IMenuItemService
    {
        Task<IResult<Guid>> CreateItemAsync(CreateMenuItemCommand menuItem);
        Task<IResult<MenuItemDto>> GetMenuItemByIdAsync(Guid Id);
        Task<IResult> DeleteItemAsync(Guid Id);
        Task<IResult<List<MenuItemDto>>> GetAllMenuItemsAsync(Guid id);
        Task<IResult<PaginationDto<MenuItemDto>>> GetPaginatedAsync(Guid Id, int pageNumber, int pageSize);
        Task<IResult> UpdateMenuItemDisplayOrderAsync(List<MenuItemDto> menuItems);
        Task<IResult> UpdateMenuItemAsync(UpdateMenuItemCommand request);
    }
}