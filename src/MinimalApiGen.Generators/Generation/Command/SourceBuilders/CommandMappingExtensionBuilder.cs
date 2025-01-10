using MinimalApiGen.Generators.Generation.Command.Results;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class CommandMappingExtensionBuilder
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
public static partial class EndpointRouteMappingExtension
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""webApplication""></param>
    public static void UseCommandRouteMaps(this WebApplication webApplication)
    {{
{BuildInternal(endpointRouteMappings)}
    }}
}}";

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

        (int Version, string FullName)[] versionWithNames = endpointRouteMappings.ToArray()
                                                                                 .Select(mapping => (mapping.Version, $"{mapping.ClassNamespace}.{mapping.ClassName}"))
                                                                                 .Distinct()
                                                                                 .ToArray();

        foreach ((int Version, string FullName) versionWithName in versionWithNames)
        {
            int version = versionWithName.Version;
            builder.Append("\t\t");
            builder.Append(versionWithName.FullName);
            builder.Append(" mapperV");
            builder.Append(version);
            builder.AppendLine(" = new();");
        }
        builder.AppendLine();

        foreach ((int Version, string FullName) versionWithName in versionWithNames)
        {
            int version = versionWithName.Version;
            builder.Append("\t\t");
            builder.Append("RouteGroupBuilder apiVersionRouteV");
            builder.Append(version);
            builder.Append(" = webApplication.GetApiVersionRoute(");
            builder.Append(version);
            builder.AppendLine(");");
        }
        builder.AppendLine();

        foreach (EndpointRouteMappingResult endpointRouteMapping in endpointRouteMappings)
        {
            int version = endpointRouteMapping.Version;
            builder.Append("\t\t");
            builder.Append("mapperV");
            builder.Append(version);
            builder.Append(".Map");
            builder.Append(endpointRouteMapping.CommandType);
            builder.Append("V");
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