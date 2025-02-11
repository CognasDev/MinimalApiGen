﻿using MinimalApiGen.Generators.Generation.Query.Results;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

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
    public static string Build(ReadOnlySpan<QueryRouteMappingResult> endpointRouteMappings) =>
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
    public static void UseQueryRouteMaps(this WebApplication webApplication)
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
    private static string BuildInternal(ReadOnlySpan<QueryRouteMappingResult> endpointRouteMappings)
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

        foreach (QueryRouteMappingResult endpointRouteMapping in endpointRouteMappings)
        {
            int version = endpointRouteMapping.Version;
            builder.Append("\t\t");
            builder.Append("mapperV");
            builder.Append(version);
            if (endpointRouteMapping.QueryType == QueryType.Get)
            {
                builder.Append(".MapGetV");
            }
            else if (endpointRouteMapping.QueryType == QueryType.GetById)
            {
                builder.Append(".MapGetByIdV");
            }
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