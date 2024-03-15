
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Branches;
using GeoCoordinatePortable;
using Mapster;
using Microsoft.EntityFrameworkCore;



namespace CodeCampRestora.Application.Features.Branches.Queries.GetByLocation;

public class GetByLocationQueryHandler : IQueryHandler<GetByLocationQuery, IResult<List<BranchListDTO>>>
{
    public readonly IUnitOfWork _unitOfWork;
    public GetByLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<List<BranchListDTO>>> Handle(GetByLocationQuery request, CancellationToken cancellationToken)
    {


        var branch = await _unitOfWork
               .Branches
               .IncludeProps(a => a.Address).ToListAsync();


        GeoCoordinate requestedLocation = new GeoCoordinate(request.Latitude, request.Longitude);




        var nearestBranch = branch
           .Select(branch =>  new
           {
               Branch = branch,
               Distance = new GeoCoordinate(branch.Address.Longitude, branch.Address.Latitude)
                               .GetDistanceTo(requestedLocation)
           })
           .OrderBy(x => x.Distance)
           .First();
        Console.WriteLine(nearestBranch);


        var nearestBranchDto = nearestBranch.Branch.Adapt<BranchListDTO>();



        return Result<List<BranchListDTO>>.Success(new List<BranchListDTO> { nearestBranchDto });


    }


}
