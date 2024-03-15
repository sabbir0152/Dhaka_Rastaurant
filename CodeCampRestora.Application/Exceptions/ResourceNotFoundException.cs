using System.Net;

namespace CodeCampRestora.Application.Exceptions;

public class ResourceNotFoundException : CommonException
{
    public ResourceNotFoundException() : base() { }

    public ResourceNotFoundException(string message) : base(message) { }

    public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
