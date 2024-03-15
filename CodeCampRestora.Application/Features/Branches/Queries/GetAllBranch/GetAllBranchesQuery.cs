using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;



namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public record GetAllBranchesQuery : IQuery<IResult<List<BranchListDTO>>>
{
    public Guid Id { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetAllBranchesQuery(Guid id,int pageNumber, int pageSize)
    {
        Id = id;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}



