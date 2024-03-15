using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : ICommandHandler<UpdateBranchCommand, IResult<BranchDTO>>
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IDateTimeService _dateTimeService;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork, IDateTimeService dateTimeService)
    {
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
    }
    

    public async Task<IResult<BranchDTO>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branchEO = await _unitOfWork
            .Branches
            .IncludeProps(
                branch => branch.Address,
                branch => branch.CuisineTypes,
                branch => branch.OpeningClosingTimes)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (branchEO is null)
        {
            return Result<BranchDTO>.Failure(
                StatusCodes.Status404NotFound,
                BranchErrors.NotFound);
        }

        request.Adapt(branchEO);
        branchEO.OpeningClosingTimes = request.OpeningClosingTimes!.Select(x => new OpeningClosingTime
        {
            Day = x.Day,
            OpeningHours = _dateTimeService.ConvertToTimeOnly(x.OpeningHours),
            ClosingHours = _dateTimeService.ConvertToTimeOnly(x.ClosingHours),
            IsClosed = x.IsClosed

        }).ToList();
        await _unitOfWork.Branches.UpdateAsync(branchEO.Id, branchEO);
        var branchDTO = branchEO.Adapt<BranchDTO>();

        return Result<BranchDTO>.Success(branchDTO);
    }
}
