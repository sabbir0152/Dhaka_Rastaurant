using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
public class UpdateMenuItemCommandHandler : ICommandHandler<UpdateMenuItemCommand, IResult>
{
    private readonly IMenuItemService _menuItemService;
    public UpdateMenuItemCommandHandler(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }
    public async Task<IResult> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuItemService.UpdateMenuItemAsync(request);
        return result;
    }
}