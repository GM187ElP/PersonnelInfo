using Microsoft.AspNetCore.Http;
using PersonnelInfo.Shared.Exceptions.Infrastructure;
using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next) => _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task InvokeAsync(HttpContext context)
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, response) = exception switch
        {
            NotFoundEntity notFoundEx => (
                HttpStatusCode.NotFound,
                new { message = notFoundEx.Message }
            ),
            InvalidOperationException invalidOpEx => (
                HttpStatusCode.BadRequest,
                new { message = invalidOpEx.Message }
            ),
            ArgumentNullException argNullEx => (
                HttpStatusCode.BadRequest,
                new { message = argNullEx.Message }
            ),
            UnauthorizedAccessException unauthEx => (
                HttpStatusCode.Unauthorized,
                new { message = unauthEx.Message }
            ),
            _ => (
                HttpStatusCode.InternalServerError,
                new { message = "An unexpected error occurred." }
            ),
        };

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
