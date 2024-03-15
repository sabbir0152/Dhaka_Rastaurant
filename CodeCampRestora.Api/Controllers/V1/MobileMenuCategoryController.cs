using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.MobieMenuCategories.Queries;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/MobileHomeMenuCategory")]
    [ApiController]
    public class MobileMenuCategoryController : ApiBaseController
    {
        [HttpGet("GetAllMobileMenuCategorty")]
        public async Task<IActionResult> GetAllMobileMenuCategories()
        {
            var result = await Sender.Send(new GetAllMobileMenuCategoryQuery());
            return result.ToActionResult();
        }
    }
}
