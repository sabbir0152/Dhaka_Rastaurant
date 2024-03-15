using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.MenuCategories.Queries;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateDisplayOrder;
using CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory;

namespace CodeCampRestora.Api.Controllers.V1;

public class MenuCategoryController : ApiBaseController
{
    [HttpPost]
    [SwaggerOperation(summary: "Create a menu category")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> Post([FromBody] CreateMenuCategoryCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpGet("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Get a menu Category",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Menu category not found", typeof(IResult))]
    public async Task<IActionResult> Get(
        [FromRoute, SwaggerParameter(Description = "Get menu category by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new GetMenuCategoryByIdQuery(id));
        return result.ToActionResult();
    }

    [HttpGet("GetAll{id:Guid}")]
    [SwaggerOperation(
        Summary = "Get all menu Categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> GetAll(
        [FromRoute, SwaggerParameter(Description = "Get all menu categories by restaurant id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new GetAllMenuCategoryQuery(id));
        return result.ToActionResult();
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Delete a menu category",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Menu item not found", typeof(IResult))]
    public async Task<IActionResult> Delete(
        [FromRoute, SwaggerParameter(Description = "Delete by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new DeleteMenuCategoryCommand(id));
        return result.ToActionResult();
    }

    [HttpPut]
    [SwaggerOperation(summary: "Update a menu category")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> Update([FromBody] UpdateMenuCategoryCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpGet("Paginated")]
    [SwaggerOperation(
        Summary = "Get paginated menu categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/Paginated?RestaurantId=3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c&PageNumber=1&PageSize=10"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> GetPaginated(Guid RestaurantId, int PageNumber, int PageSize)
    {
        var result = await Sender.Send(new GetPaginatedMenuCategoriesQuery(RestaurantId, PageNumber, PageSize));
        return result.ToActionResult();
    }

    [HttpPut("UpdateDisplayOrder")]
    [SwaggerOperation(
        Summary = "Update display order",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/UpdateDisplayOrder"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> Update(List<MenuCategoryDto> menuCategories)
    {
        var result = await Sender.Send(new UpdateMenuCategoryDisplayOrderCommand(menuCategories));
        return result.ToActionResult();
    }
}