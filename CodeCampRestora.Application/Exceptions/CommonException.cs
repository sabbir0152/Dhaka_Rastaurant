using System.Net;

namespace CodeCampRestora.Application.Exceptions;

public class CommonException : Exception
{
    public CommonException() : base() { }

    public CommonException(string message) : base(message) { }

    public CommonException(string message, Exception innerException) : base(message, innerException) { }
    public virtual HttpStatusCode StatusCode { get; }
}
