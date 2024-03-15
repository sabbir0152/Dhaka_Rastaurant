using System.Net;

namespace CodeCampRestora.Application.Exceptions;

public class BadRequestException : CommonException
{
    public BadRequestException() : base() { }

    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}