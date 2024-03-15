
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using MediatR;
using System.Windows.Input;

namespace CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
public record DeleteBranchCommand : ICommand<IResult>
{
    
    public Guid Id { get; set; }

}
