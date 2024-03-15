using CodeCampRestora.Domain.Enums;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;


namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public record UpdateBranchCommand : ICommand<IResult<BranchDTO>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
    public IList<BranchOpeningClosingTimeDTO>? OpeningClosingTimes { get; set; }
    public IList<BranchCuisineTypeDTO>? CuisineTypes { get; set; }
    public BranchAddressDTO? Address { get; set; }

}
