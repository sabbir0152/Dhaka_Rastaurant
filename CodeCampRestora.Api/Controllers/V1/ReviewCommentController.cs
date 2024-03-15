using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.ReviewComments;
using CodeCampRestora.Application.Features.ReviewComments.CommentHideCommand;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class ReviewCommentController : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewCommentCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpPatch]
    public async Task<IActionResult> CommentHide([FromBody] CommentHideCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }
}
