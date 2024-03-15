using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategory.Commands;

public class CreateMenuCategoryCommandHandler : ICommandHandler<CreateMenuCategoryCommand, IResult<Guid>>
{
    private readonly IMenuCategoryService _menuCategoryService;
    public CreateMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }
    public async Task<IResult<Guid>> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuCategoryService.CreateCategoryAsync(request);
        return result;
    }
}
