using System.Net;

namespace Euromonitor.Application.Common.Responses;

public record Response<T>
{
    public T Data { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public string Message { get; init; }
    public string Error { get; init; }
    public DateTime TimeStamp { get; init; } = DateTime.UtcNow;

    public Response(T data = default, HttpStatusCode statusCode = HttpStatusCode.OK, string message = null, string error = null)
    {
        Data = data;
        StatusCode = statusCode;
        Message = message;
        Error = error;
    }
}
