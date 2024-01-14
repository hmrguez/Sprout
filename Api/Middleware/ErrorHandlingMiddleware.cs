using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var options = new JsonSerializerOptions();
        var myContext = new ErrorResponseSerializerContext(options);
        var errorResponse = new ErrorResponse(exception.Message);
        var result = JsonSerializer.Serialize(errorResponse, myContext.ErrorResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) code;

        return context.Response.WriteAsync(result);
    } 
}

public record ErrorResponse(string Message);

[JsonSerializable(typeof(ErrorResponse[]))]
public partial class ErrorResponseSerializerContext : JsonSerializerContext
{
}
