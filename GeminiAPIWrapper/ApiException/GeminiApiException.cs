using System.Net;

namespace GeminiAPIWrapper.ApiException;

public class GeminiApiException(
    string message,
    HttpStatusCode statusCode,
    string? errorContent = null,
    Exception? innerException = null)
    : Exception($"{message} (StatusCode: {(int)statusCode})", innerException)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string? ErrorContent { get; } = errorContent;
}
