using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory
{
    public record GetAllMenuCategoryQuery(Guid Id) : IQuery<IResult<List<MenuCategoryDto>>>;
}