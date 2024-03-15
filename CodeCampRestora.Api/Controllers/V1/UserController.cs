using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.Auths.Commands.UserLogin;
using CodeCampRestora.Application.Features.Auths.Commands.UserSignup;
using CodeCampRestora.Application.Features.Auths.Commands.CreateRefreshToken;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/users")]
public class UserController : ApiBaseController
{
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "register as a user",
        Description = @"Sample Request:
        Post: api/v1/users/register
        {
            ""fullName"": ""John Doe"",
            ""email"": ""john@example.com"",
            ""password"": ""Aa123456."",
            ""phone"": ""01791654281""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "User already exists", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
    public async Task<IActionResult> Register([FromBody] UserSignupCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login as a user",
        Description = @"Sample Request:
        Post: api/v1/users/login
        {
            ""phone"": ""01791654281"",
            ""passoword"": ""Aa123456.""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IAuthResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(IAuthResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IAuthResult))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Wrong user credentials", typeof(IAuthResult))]
    public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpPost("refresh")]
    [SwaggerOperation(
        Summary = "refresh token",
        Description = @"Sample Request:
        Post: api/v1/users/refresh
        {
            ""accessToken"": ""provided token"",
            ""refreshToken"": ""provided refresh token""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IAuthResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Refresh token creation failed", typeof(IAuthResult))]
    public async Task<IActionResult> RefreshToken([FromBody] CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }
}
