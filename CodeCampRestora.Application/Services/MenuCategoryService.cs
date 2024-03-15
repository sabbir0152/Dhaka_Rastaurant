using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Services;
[ScopedLifetime]
public class MenuCategoryService : IMenuCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    public MenuCategoryService(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
    }
    public async Task<IResult<Guid>> CreateCategoryAsync(CreateMenuCategoryCommand menuCategoryDto)
    {
        // var imageEO = menuCategoryDto.Image.Adapt<Image>();
        // var result = await _imageService.UploadImageAsync(imageEO);

        var menuCategory = menuCategoryDto.Adapt<MenuCategory>();
        menuCategory.ImagePath = menuCategoryDto.Image.Name;
        
        await _unitOfWork.MenuCategory.AddAsync(menuCategory);
        await _unitOfWork.SaveChangesAsync();

        // if(result.IsSuccess)
        // {
        //     var imageId = result.Data;
            
        //     menuCategory.ImageId = imageId;
        //     await _unitOfWork.MenuCategory.AddAsync(menuCategory);
        //     await _unitOfWork.SaveChangesAsync();
        // }

        return Result<Guid>.Success(menuCategory.Id);
    }

    public async Task<Models.IResult> DeleteCategoryAsync(Guid Id)
    {
        var MenuCategory = await _unitOfWork.MenuCategory.GetByIdAsync(Id);

        if (MenuCategory == null) return Result.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Category not found!"));
            
        await _unitOfWork.MenuCategory.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<IResult<List<MenuCategoryDto>>> GetAllMobileMenuCategoryAsync()
    {
        var MenuCategories = await _unitOfWork.MenuCategory.GetAllAsync();
        var MenuCategoriesDto = MenuCategories.Adapt<List<MenuCategoryDto>>();
        return Result<List<MenuCategoryDto>>.Success(MenuCategoriesDto);
    }

    public async Task<IResult<List<MenuCategoryDto>>> GetAllMenuCategoryAsync(Guid Id)
    {
        var MenuCategories = await _unitOfWork.MenuCategory.GetAllByIdAsync(Id);
        var MenuCategoriesDto = MenuCategories.Adapt<List<MenuCategoryDto>>();
        return Result<List<MenuCategoryDto>>.Success(MenuCategoriesDto);
    }

    public async Task<IResult<MenuCategoryDto>> GetMenuCategoryByIdAsync(Guid Id)
    {
        var MenuCategory = await _unitOfWork.MenuCategory.GetByIdAsync(Id);
        if (MenuCategory == null)
        {
            return Result<MenuCategoryDto>.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound("Menu Category not found"));
        }
        var menuCategoryDto = MenuCategory.Adapt<MenuCategoryDto>();
        return Result<MenuCategoryDto>.Success(menuCategoryDto);
    }

    public async Task<IResult<PaginationDto<MenuCategoryDto>>> GetPaginatedMenuCategoryAsync(
        Guid restaurantId, int pageNumber, int pageSize
    )
    {
        var menuCategoriesEO = await _unitOfWork.MenuCategory.GetPaginatedByIdAsync(
            restaurantId,
            pageNumber, 
            pageSize
        );
        var menuCategoriesDto = menuCategoriesEO.Adapt<List<MenuCategoryDto>>();
        var response = new PaginationDto<MenuCategoryDto>(menuCategoriesDto, menuCategoriesEO.TotalCount, menuCategoriesEO.TotalPages);
        return Result<PaginationDto<MenuCategoryDto>>.Success(response);
    }

    public async Task<Models.IResult> UpdateMenuCategoryAsync(UpdateMenuCategoryCommand request)
    {
        var menuCategoriesEO = await _unitOfWork.MenuCategory.GetByIdAsync(request.Id);

        if (menuCategoriesEO == null)
        {
            return Result.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound($"Menu Category not found with Id {request.Id}"));
        }

        var menuCategory = request.Adapt<MenuCategory>();
        menuCategory.ImagePath = "string";

        await _unitOfWork.MenuCategory.UpdateAsync(request.Id, menuCategory);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(StatusCodes.Status204NoContent);
    }

    public async Task<Models.IResult> UpdateMenuCategoryDisplayOrderAsync(List<MenuCategoryDto> menuCategories)
    {
        var menuCategoriesEO = menuCategories.Adapt<List<MenuCategory>>();
        var result = await _unitOfWork.MenuCategory.UpdateMenuCategoryAsync(menuCategoriesEO);
        if (result.IsSuccess)
        {
            await _unitOfWork.SaveChangesAsync();
        }
        return result;
    }

    // public async Task<IResult<PaginationDto<MenuCategory>>> GetPaginatedMenuCategoryAsync(int pageNumber, int pageSize)
    // {
    //     var menuCategoriesEO = await _unitOfWork.MenuCategory.GetPaginatedAsync(pageNumber, pageSize);
    //     var response= new PaginationDto<MenuCategory>(menuCategoriesEO, menuCategoriesEO.TotalCount, menuCategoriesEO.TotalPages);
    //     return Result<PaginationDto<MenuCategory>>.Success(response);
    // }

}