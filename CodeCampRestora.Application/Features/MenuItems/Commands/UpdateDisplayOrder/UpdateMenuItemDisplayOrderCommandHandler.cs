using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.PutDisplayOrder
{
    public class PutMenuItemDisplayOrderCommandHandler : ICommandHandler<UpdateMenuItemDisplayOrderCommnad, IResult>
    {
        private readonly IMenuItemService _menuItemService;
        public PutMenuItemDisplayOrderCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public Task<IResult> Handle(UpdateMenuItemDisplayOrderCommnad request, CancellationToken cancellationToken)
        {
            var result = _menuItemService.UpdateMenuItemDisplayOrderAsync(request.MenuItems);
            return result;
        }
    }
}