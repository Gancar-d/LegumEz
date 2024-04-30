using System.Net;
using System.Text.Json;
using LegumEz.Infrastructure.Persistance.Exceptions;

namespace LegumEz.WebApi.Middlewares;

internal class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        var errorDetails = new ErrorDetails();

        switch (exception)
        {
            case EntityNotFoundException entityNotFoundException:
                _logger.LogError(entityNotFoundException, "Could not found {EntityType} with ID : {EntityId}",
                    entityNotFoundException.EntityType.Name, entityNotFoundException.EntityId);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                errorDetails.StatusCode = context.Response.StatusCode;
                errorDetails.Message = "Entity not found";
                errorDetails.Details =
                    $"Could not found {entityNotFoundException.EntityType.Name} with ID : {entityNotFoundException.EntityId}";
                break;
            default:
                _logger.LogError(exception, "Something went wrong: {ExceptionMessage}", exception.Message);
                errorDetails.StatusCode = context.Response.StatusCode;
                errorDetails.Message = "Internal Server Error from the custom middleware.";
                errorDetails.Details = exception.StackTrace ?? string.Empty;
                break;
        }

        await context.Response.WriteAsync(errorDetails.ToString());
    }
}

internal record ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Details { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}