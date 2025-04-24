using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MusicCRUD.Server.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        Console.WriteLine($"💥 Exception: {context.Exception.Message}");
        _logger.LogError($"💥 Exception: {context.Exception.Message}");

        context.Result = new ObjectResult(new
        {
            error = "An unexpected error occurred."
        })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
