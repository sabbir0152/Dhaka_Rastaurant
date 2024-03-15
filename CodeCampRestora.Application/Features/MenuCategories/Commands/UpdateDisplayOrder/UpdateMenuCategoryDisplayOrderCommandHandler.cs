using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateDisplayOrder;
public class UpdateMenuCategoryDisplayOrderCommandHandler : ICommandHandler<UpdateMenuCategoryDisplayOrderCommand, IResult>
{
    private readonly IMenuCategoryService _menuCategoryService;
    public UpdateMenuCategoryDisplayOrderCommandHandler(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }

    public Task<IResult> Handle(UpdateMenuCategoryDisplayOrderCommand request, CancellationToken cancellationToken)
    {
        var result = _menuCategoryService.UpdateMenuCategoryDisplayOrderAsync(request.MenuCategories);
        return result;
    }
}
