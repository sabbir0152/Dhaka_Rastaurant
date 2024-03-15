using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem
{
    public record DeleteMenuItemCommand(Guid Id) : ICommand<IResult>;
}