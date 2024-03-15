using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem
{
    public class DeleteMenuItemCommandHandler : ICommandHandler<DeleteMenuItemCommand, IResult>
    {
        private readonly IMenuItemService _menuItemService;
        public DeleteMenuItemCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        public async Task<IResult> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.DeleteItemAsync(request.Id);
            return result;
        }
    }
}