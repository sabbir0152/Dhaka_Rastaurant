
using FluentValidation;
using CodeCampRestora.Application.Common;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBrachValidator : ApplicationValidator<UpdateBranchCommand>
{
    public UpdateBrachValidator()
    {
        RuleFor(item => item.Name).NotEmpty().WithMessage("Branch Name can't be empty");
    }
}
