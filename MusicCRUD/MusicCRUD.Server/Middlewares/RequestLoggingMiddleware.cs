namespace MusicCRUD.Server.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var logText = $"[{DateTime.Now}] {request.Method} {request.Path}";

        // Log to file (simplified)
        await File.AppendAllTextAsync($"Logs/{DateTime.Now:yyyy-MM-dd}.txt", logText + Environment.NewLine);

        await _next(context);
    }
}

