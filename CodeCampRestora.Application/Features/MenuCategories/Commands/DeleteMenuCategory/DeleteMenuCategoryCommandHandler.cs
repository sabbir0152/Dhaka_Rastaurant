using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;

public class DeleteMenuCategoryCommandHandler : ICommandHandler<DeleteMenuCategoryCommand, IResult>
{
    private readonly IMenuCategoryService _menuCategoryService;
    public DeleteMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService)
    {
        _menuCategoryService = menuCategoryService;
    }
    public async Task<IResult> Handle(DeleteMenuCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _menuCategoryService.DeleteCategoryAsync(request.Id);
        return result;
    }
}
