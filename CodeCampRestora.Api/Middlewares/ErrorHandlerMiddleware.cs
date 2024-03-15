using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Exceptions;


namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CommonException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = "application/json";

                switch (ex)
                {
                    case BadRequestException validationEx:
                        await HandleValidationException(context, validationEx);
                        break;
                    case AuthorizationException authEx:
                        await HandleAuthorizationException(context, authEx);
                        break;
                    case DataAccessException dataEx:
                        await HandleDataAccessException(context, dataEx);
                        break;
                    case ResourceNotFoundException resourceEx:
                        await HandleResourceNotFoundException(context, resourceEx);
                        break;
                    case NotImplementationException notImplementationEx:
                        await HandleNotImplementationException(context, notImplementationEx);
                        break;
                    case ApplicationValidationException validationEx:
                        await HandleValidationException(context, validationEx);
                        break;
                    default:
                        await HandleUnknownException(context, ex);
                        break;
                }
            }
            catch (Exception ex)
            {
                await HandleUnknownException(context, ex);
            }
        }

        private async Task HandleValidationException(HttpContext context, BadRequestException ex)
        {
            var error = JsonConvert.SerializeObject(new { error = ex.Message, statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleAuthorizationException(HttpContext context, AuthorizationException ex)
        {
            var error = JsonConvert.SerializeObject(new { error = ex.Message, statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleDataAccessException(HttpContext context, DataAccessException ex)
        {
            var error = JsonConvert.SerializeObject(new { error = ex.Message, statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleResourceNotFoundException(HttpContext context, ResourceNotFoundException ex)
        {
            var error = JsonConvert.SerializeObject(new { error = ex.Message, statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleNotImplementationException(HttpContext context, Exception ex)
        {
            var error = JsonConvert.SerializeObject(new { error = ex.Message, statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleUnknownException(HttpContext context, Exception ex)
        {
            var error = JsonConvert.SerializeObject(new { error = "An unexpected error occurred.", statusCode = context.Response.StatusCode });
            await context.Response.WriteAsync(error);
        }

        private async Task HandleValidationException(HttpContext context, ApplicationValidationException ex)
        {
            var errors = ex.Messages.Select(message =>
                Error.NotValidated(message.Type, message.Description)).ToArray();

            var response = Result.Failure(errors);
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(response,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
