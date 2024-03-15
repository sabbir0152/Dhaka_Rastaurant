using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;
using CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;
using CodeCampRestora.Application.Features.Reviews.Commands.IsReviewHidden;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class ReviewController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
    {
        var request = new GetAllReviewQuery(pageNumber, pageSize);
        var response = await Sender.Send(request);
        return response.ToActionResult();
    }
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Reviews",
        Description = @"Sample Request:
            Get: api/v1/Review
            {
            ""BranchId"": ""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""OrderId"":""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""Rating"":""4"",
            ""Description"":""Someting""
            }"
    )]
    public async Task<Application.Models.IResult> CreateReviews([FromBody] CreateReviewCommand reviewCommand)
    {
        var result = await Sender.Send(reviewCommand);
        return result;
    }
    [HttpPatch]
    [SwaggerOperation(
        Summary = "Hide or Show a Review",
        Description = @"Sample Request:
            Patch: api/v1/IsReviewHidden
            {
             ""hideReview"": true
            }"
    )]
    public async Task<IActionResult> IsReviewHiddenUpdate([FromBody] HiddenReviewCommand hiddenReviewCommand)
    {
        var result = await Sender.Send(hiddenReviewCommand);
        return result.ToActionResult();
    }
}
