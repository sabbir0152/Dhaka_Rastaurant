using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries
{
    public record GetMenuCategoryByIdQuery(Guid Id) : IQuery<IResult<MenuCategoryDto>>;
}