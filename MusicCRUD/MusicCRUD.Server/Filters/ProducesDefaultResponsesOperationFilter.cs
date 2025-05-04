using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MusicCRUD.Server.Filters;

public class ProducesDefaultResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attr = context.MethodInfo
            .GetCustomAttribute<ProducesDefaultResponsesAttribute>();

        if (attr == null)
            return;

        // Add 400
        operation.Responses.TryAdd("400", new OpenApiResponse
        {
            Description = "Bad Request"
        });

        // Add 422
        operation.Responses.TryAdd("422", new OpenApiResponse
        {
            Description = "Unprocessable Entity"
        });

        // Optionally add 500
        if (attr.IncludeInternalServerError)
        {
            operation.Responses.TryAdd("500", new OpenApiResponse
            {
                Description = "Internal Server Error"
            });
        }
    }
}

