using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;
using CodeCampRestora.Application.Features.Auths.Commands.CreateRefreshToken;
using CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/owners")]
public class OwnerController : ApiBaseController
{
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "register as a restaurant owner",
        Description = @"Sample Request:
        Post: api/v1/owners/register
        {
            ""fullName"": ""John Doe"",
            ""restaurantName"": ""KFC"",
            ""email"": ""john@example.com"",
            ""password"": ""Aa123456.""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "User already exists", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
    public async Task<IActionResult> Register(
        [FromBody, SwaggerRequestBody(Description = "Restaurant owner signup payload", Required = true)]
        OwnerSignupCommand command)
    {
        var result = await Sender.Send(command);
        if (result.IsSuccess) return Ok(result);
        return result.ToActionResult();
    }

    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login as a restaurant owner",
        Description = @"Sample Request:
        Post: api/v1/owners/login
        {
            ""username"": ""john@example.com"",
            ""passoword"": ""Aa123456.""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IAuthOwnerResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(IAuthOwnerResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IAuthOwnerResult))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Wrong user credentials", typeof(IAuthOwnerResult))]
    public async Task<IActionResult> Login(
        [FromBody, SwaggerRequestBody(Description = "Restaurant owner login payload", Required = true)]
        OwnerLoginCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpPost("refresh")]
    [SwaggerOperation(
        Summary = "refresh token",
        Description = @"Sample Request:
        Post: api/v1/owners/refresh
        {
            ""accessToken"": ""provided token"",
            ""refreshToken"": ""provided refresh token""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IAuthOwnerResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Refresh token creation failed", typeof(IAuthOwnerResult))]
    public async Task<IActionResult> RefreshToken(
        [FromBody, SwaggerRequestBody(Description = "Refresh token creation payload", Required = true)]
        CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }
}
