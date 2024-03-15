using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetAllMenuItems;

public record GetAllMenuItemsQuery(Guid Id) : IQuery<IResult<List<MenuItemDto>>>;
