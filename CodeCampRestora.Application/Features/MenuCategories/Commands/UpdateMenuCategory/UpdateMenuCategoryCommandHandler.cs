using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
public class UpdateMenuCategoryCommandHandler : ICommandHandler<UpdateMenuCategoryCommand, IResult>
{
    private readonly IMenuCategoryService _menuCategoryService;
    public UpdateMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }
    public async Task<IResult> Handle(UpdateMenuCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuCategoryService.UpdateMenuCategoryAsync(request);
        return result;
    }
}