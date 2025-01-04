using MinimalApiGen.Generators.Query.Results;
using System;
using System.Text;

namespace MinimalApiGen.Generators.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class QueryMappingExtensionBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteMappings"></param>
    /// <returns></returns>
    public static string Build(ReadOnlySpan<EndpointRouteMappingResult> endpointRouteMappings) =>
@$"using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class EndpointRouteMappingExtension
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""webApplication""></param>
    public static void UseMinimalApiGenEndpointRouteMaps(this WebApplication webApplication)
    {{
{BuildInternal(endpointRouteMappings)}
    }}
}}
";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteMappings"></param>
    /// <returns></returns>
    private static string BuildInternal(ReadOnlySpan<EndpointRouteMappingResult> endpointRouteMappings)
    {
        StringBuilder builder = new();
        foreach (EndpointRouteMappingResult endpointRouteMapping in endpointRouteMappings)
        {
            int version = endpointRouteMapping.Version;
            builder.Append("\t\t");
            builder.Append(endpointRouteMapping.ClassNamespace);
            builder.Append(".");
            builder.Append(endpointRouteMapping.ClassName);
            builder.Append(" mapperV");
            builder.Append(version);
            builder.AppendLine(" = new();");
            builder.Append("\t\t");
            builder.Append("RouteGroupBuilder apiVersionRouteV");
            builder.Append(version);
            builder.Append(" = webApplication.GetApiVersionRoute(");
            builder.Append(version);
            builder.AppendLine(");");
            builder.Append("\t\t");
            builder.Append("mapperV");
            builder.Append(version);
            builder.Append(".MapGetV");
            builder.Append(version);
            builder.Append("(apiVersionRouteV");
            builder.Append(version);
            builder.AppendLine(");");
        }
        string result = builder.ToString();
        return result;
    }

    #endregion
}