using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Queries
{
    public record GetMenuItemByIdQuery(Guid Id) : IQuery<IResult<MenuItemDto>>;
}