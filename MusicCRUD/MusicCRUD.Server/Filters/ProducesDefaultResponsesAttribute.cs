using System;
namespace MusicCRUD.Server.Filters;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ProducesDefaultResponsesAttribute : Attribute
{
    public bool IncludeInternalServerError { get; }

    public ProducesDefaultResponsesAttribute(bool includeInternalServerError = true)
    {
        IncludeInternalServerError = includeInternalServerError;
    }
}
