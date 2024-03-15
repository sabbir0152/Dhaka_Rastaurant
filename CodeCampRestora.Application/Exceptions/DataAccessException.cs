using System.Net;

namespace CodeCampRestora.Application.Exceptions;
public class DataAccessException : CommonException
{
    public DataAccessException() : base() { }

    public DataAccessException(string message) : base(message) { }

    public DataAccessException(string message, Exception innerException) : base(message, innerException) { }

    public override HttpStatusCode StatusCode => HttpStatusCode.ServiceUnavailable;
}
