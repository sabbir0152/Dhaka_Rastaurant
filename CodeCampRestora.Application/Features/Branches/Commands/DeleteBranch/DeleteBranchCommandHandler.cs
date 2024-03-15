
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandHandler : ICommandHandler<DeleteBranchCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBranchCommandHandler(IUnitOfWork unitOfWork)
    {
         _unitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Branch Not Found");
        }
        await _unitOfWork.Branches.DeleteAsync(branch.Id);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
        
    }
}
 