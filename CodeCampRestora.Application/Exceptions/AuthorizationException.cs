using System.Net;

namespace CodeCampRestora.Application.Exceptions;

public class AuthorizationException : CommonException
{
    public AuthorizationException() : base() { }

    public AuthorizationException(string message) : base(message) { }

    public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
