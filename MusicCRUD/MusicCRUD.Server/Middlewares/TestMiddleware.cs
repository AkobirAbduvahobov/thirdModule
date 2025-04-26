namespace MusicCRUD.Server.Middlewares;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("Befare Controlerdan");

        await _next(context);

        Console.WriteLine("After Controller");
    }
}
