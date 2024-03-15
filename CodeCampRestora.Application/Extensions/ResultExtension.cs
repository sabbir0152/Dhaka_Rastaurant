using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Extensions;

public static class ResultExtension
{
    public static IActionResult ToActionResult(this IResult result)
    {
        var response = new JsonResult(result)
        {
            StatusCode = result.StatusCode
        };

        return response;
    }
}