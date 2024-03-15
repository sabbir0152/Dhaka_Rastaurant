using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;

namespace CodeCampRestora.Application.Services;
[ScopedLifetime]
public class MenuItemService : IMenuItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    public MenuItemService(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
    }
    public async Task<IResult<Guid>> CreateItemAsync(CreateMenuItemCommand menuItemDto)
    {
        // var imageEO = menuItemDto.Image.Adapt<Image>();
        // var result = await _imageService.UploadImageAsync(imageEO);

        var menuItem = menuItemDto.Adapt<MenuItem>();
        menuItem.ImagePath = menuItemDto.Image.Name;
        
        await _unitOfWork.MenuItem.AddAsync(menuItem);
        await _unitOfWork.SaveChangesAsync();

        // if(result.IsSuccess)
        // {
        //     var imageId = result.Data;
            
        //     menuItem.ImageId = imageId;
        //     await _unitOfWork.MenuItem.AddAsync(menuItem);
        //     await _unitOfWork.SaveChangesAsync();
        // }
        return Result<Guid>.Success(menuItem.Id);
    }

    public async Task<IResult> DeleteItemAsync(Guid Id)
    {
        var MenuItem = await _unitOfWork.MenuItem.GetByIdAsync(Id);
        if(MenuItem is null) return Result.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Item not found!"));
        await _unitOfWork.MenuItem.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success(200);
    }

    public async Task<IResult<List<MenuItemDto>>> GetAllMenuItemsAsync(Guid id)
    {
        var MenuItemsEO = await _unitOfWork.MenuItem.GetAllByIdAsync(id);
        var MenuItemsDto = MenuItemsEO.Adapt<List<MenuItemDto>>();
        return Result<List<MenuItemDto>>.Success(MenuItemsDto);
    }

    public async Task<IResult<MenuItemDto>> GetMenuItemByIdAsync(Guid Id)
    {
        var MenuItem = await _unitOfWork.MenuItem.GetByIdAsync(Id);
        if (MenuItem == null)
        {
            return Result<MenuItemDto>.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound("Item not found"));
        }
        var menuItemDto = MenuItem.Adapt<MenuItemDto>();
        return Result<MenuItemDto>.Success(menuItemDto);
    }

    public async Task<IResult<PaginationDto<MenuItemDto>>> GetPaginatedAsync(
        Guid Id, int pageNumber, int pageSize
    )
    {
        var menuItemsEO = await _unitOfWork.MenuItem.GetPaginatedByIdAsync(
            Id,
            pageNumber, 
            pageSize
        );
        var menuItemsDto = menuItemsEO.Adapt<List<MenuItemDto>>();
        var response = new PaginationDto<MenuItemDto>(menuItemsDto, menuItemsEO.TotalCount, menuItemsEO.TotalPages);
        return Result<PaginationDto<MenuItemDto>>.Success(response);
    }

    public async Task<IResult> UpdateMenuItemAsync(UpdateMenuItemCommand request)
    {
        var menuItemEO = await _unitOfWork.MenuItem.GetByIdAsync(request.Id);

        if (menuItemEO == null)
        {
            return Result.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound($"Menu item not found with Id {request.Id}"));
        }

        var menuItem = request.Adapt<MenuItem>();
        menuItem.ImagePath = "string";

        await _unitOfWork.MenuItem.UpdateAsync(request.Id, menuItem);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(StatusCodes.Status204NoContent);
    }

    public async Task<IResult> UpdateMenuItemDisplayOrderAsync(List<MenuItemDto> menuItems)
    {
        var menuItemsEO = menuItems.Adapt<List<MenuItem>>();
        var result = await _unitOfWork.MenuItem.UpdateMenuItemsAsync(menuItemsEO);
        if (result.IsSuccess)
        {
            await _unitOfWork.SaveChangesAsync();
        }
        return result;
    }
}