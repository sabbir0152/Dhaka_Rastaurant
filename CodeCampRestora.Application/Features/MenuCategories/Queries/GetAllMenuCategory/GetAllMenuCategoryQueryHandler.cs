using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetAllMenuCategory
{
    public class GetAllMenuCategoryQueryHandler : IQueryHandler<GetAllMenuCategoryQuery, IResult<List<MenuCategoryDto>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;
        public GetAllMenuCategoryQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public Task<IResult<List<MenuCategoryDto>>> Handle(GetAllMenuCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = _menuCategoryService.GetAllMenuCategoryAsync(request.Id);
            return result;
        }
    }
}