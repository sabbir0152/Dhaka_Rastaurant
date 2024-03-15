using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Features.Branches.Queries.GetById;
using CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;
using CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
using CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetByLocation;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/branch")]
public class BranchesController : ApiBaseController
{
    private readonly ILogger<BranchesController> _logger;
    private readonly IMediator _mediator;

    public BranchesController(ILogger<BranchesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("resturant/{resturantId}")]
    [SwaggerOperation(
        Summary = "Get all branches for a restaurant",
        Description = @"Sample Request:
        GetAll: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Branch not found", typeof(IResult))]
    public async Task<IActionResult> GetAll(Guid resturantId,int pageNumber, int pageSize)
    {
        var result = await Sender.Send(new GetAllBranchesQuery(resturantId, pageNumber,pageSize));
        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a branch by ID",
        Description = @"Sample Request:
        Get: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await Sender.Send(new GetBranchByIdQuery(id));
        return result.ToActionResult();
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new branch",
        Description = @"Sample Request:
        Post: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> Post([FromBody] CreateBranchCommand newItem)
    {
        var result = await Sender.Send(newItem);
        return result.ToActionResult();
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Update an existing branch",
        Description = @"Sample Request:
        Put: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> Put(UpdateBranchCommand updatedItem)
    {
        var result = await Sender.Send(updatedItem);
        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a branch",
        Description = @"Sample Request:
        Delete: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await Sender.Send(new DeleteBranchCommand { Id = id });
        return result.ToActionResult();
    }
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Branches by Location",
        Description = @"Sample Request:
        GetAll: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> GetAll(double Latitude, double Longitude)
    {
        var result = await Sender.Send(new GetByLocationQuery(Latitude,Longitude));
        return result.ToActionResult();
    }

}


