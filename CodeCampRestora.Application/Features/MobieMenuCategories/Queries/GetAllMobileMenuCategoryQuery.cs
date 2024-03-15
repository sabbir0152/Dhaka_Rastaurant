using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MobieMenuCategories.Queries
{
    public class GetAllMobileMenuCategoryQuery : IQuery<IResult<List<MenuCategoryDto>>>
    {
    }
}
