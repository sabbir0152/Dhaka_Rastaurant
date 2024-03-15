using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;


namespace CodeCampRestora.Application.Features.MobieMenuCategories.Queries
{
    public class GetAllMobileMenuCategoryQueryHandler : IQueryHandler<GetAllMobileMenuCategoryQuery, IResult<List<MenuCategoryDto>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public GetAllMobileMenuCategoryQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public Task<IResult<List<MenuCategoryDto>>> Handle(GetAllMobileMenuCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = _menuCategoryService.GetAllMobileMenuCategoryAsync();
            return result;
        }
    }
}
