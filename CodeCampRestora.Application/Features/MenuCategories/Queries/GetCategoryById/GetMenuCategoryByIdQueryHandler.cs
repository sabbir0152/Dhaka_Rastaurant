using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries
{
    public class GetMenuCategoryByIdQueryHandler : IQueryHandler<GetMenuCategoryByIdQuery, IResult<MenuCategoryDto>>
    {
        private readonly IMenuCategoryService _menuCategoryService;
        public GetMenuCategoryByIdQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public async Task<IResult<MenuCategoryDto>> Handle(GetMenuCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _menuCategoryService.GetMenuCategoryByIdAsync(request.Id);
            return result;
        }
    }
}