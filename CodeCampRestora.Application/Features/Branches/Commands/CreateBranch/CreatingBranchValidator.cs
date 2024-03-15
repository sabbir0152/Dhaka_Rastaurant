using FluentValidation;
using CodeCampRestora.Application.Common;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class CreatingBranchValidator : ApplicationValidator<CreateBranchCommand>
{
    public CreatingBranchValidator()
    {
        RuleFor(item => item.Name).NotEmpty().WithMessage("Branch Name can't be empty");
        RuleFor(model => model.Address.Latitude).LessThanOrEqualTo(90)
                                .GreaterThanOrEqualTo(-90)
                                .WithMessage("Latitude must be between -90 <-> 90 degress.");

        RuleFor(model => model.Address.Longitude).LessThanOrEqualTo(180)
                                         .GreaterThanOrEqualTo(-180)
                                         .WithMessage("Longitude must be between -180 <-> 180 degress.");
    }
}
