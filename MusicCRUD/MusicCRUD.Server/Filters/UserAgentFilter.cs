using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MusicCRUD.Server.Filters;

public class UserAgentFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

        if (userAgent.Contains("Postman", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new ContentResult
            {
                StatusCode = 403,
                Content = "🚫 Requests from Postman are not allowed."
            };
        }
    }
}

