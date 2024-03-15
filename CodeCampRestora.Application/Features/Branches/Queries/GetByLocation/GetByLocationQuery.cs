
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetByLocation;

public record GetByLocationQuery :IQuery<IResult<List<BranchListDTO>>>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public GetByLocationQuery(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

}
