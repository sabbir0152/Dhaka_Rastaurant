using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.MenuItems.Queries;
using CodeCampRestora.Application.Features.MenuItems.Queries.GetAllMenuItems;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Commands.PutDisplayOrder;
using CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;
using CodeCampRestora.Application.Features.MenuCategories.Commands.UpdateMenuCategory;

namespace CodeCampRestora.Api.Controllers.V1
{
    public class MenuItemController : ApiBaseController
    {
        [HttpPost]
        [SwaggerOperation(summary: "create a menu item")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IActionResult> Post([FromBody] CreateMenuItemCommand command)
        {
            var result = await Sender.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Get a menu item",
            Description = @"Sample Request:
            Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Menu item not found", typeof(IResult))]
        public async Task<IActionResult> GetById(
            [FromRoute, SwaggerParameter(Description = "Get menu item by id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new GetMenuItemByIdQuery(id));
            return result.ToActionResult();
        }

        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Delete a menu item",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Menu item not found", typeof(IResult))]
        public async Task<IActionResult> Delete(
            [FromRoute, SwaggerParameter(Description = "Delete by id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new DeleteMenuItemCommand(id));
            return result.ToActionResult();
        }

        [HttpGet("GetAll{id:Guid}")]
        [SwaggerOperation(
            Summary = "Get all menu items",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Branch id not found", typeof(IResult))]
        public async Task<IActionResult> GetAll(
            [FromRoute, SwaggerParameter(Description = "Get all menu items by branch id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new GetAllMenuItemsQuery(id));
            return result.ToActionResult();
        }

        [HttpPut]
        [SwaggerOperation(summary: "Update a menu item")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        public async Task<IActionResult> Update([FromBody] UpdateMenuItemCommand command)
        {
            var result = await Sender.Send(command);
            return result.ToActionResult();
        }

        [HttpGet("Paginated")]
        [SwaggerOperation(
            Summary = "Get paginated menu items with branchId",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/Paginated?BranchId=3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c&PageNumber=1&PageSize=10"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Branch id not found", typeof(IResult))]
        public async Task<IActionResult> GetPaginated(Guid BranchId, int PageNumber, int PageSize)
        {
            var result = await Sender.Send(new GetPaginatedMenuItemsQuery(BranchId, PageNumber, PageSize));
            return result.ToActionResult();
        }

        [HttpPut("UpdateDisplayOrder")]
        [SwaggerOperation(
            Summary = "Update display order",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/UpdateDisplayOrder"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Menu item not found", typeof(IResult))]
        public async Task<IActionResult> Update(List<MenuItemDto> menuItems)
        {
            var result = await Sender.Send(new UpdateMenuItemDisplayOrderCommnad(menuItems));
            return result.ToActionResult();
        }
    }
}