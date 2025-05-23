﻿using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class MappingExtensionsBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteMappings"></param>
    /// <returns></returns>
    public static string Build(ReadOnlySpan<RouteMappingResult> endpointRouteMappings) =>
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
    public static void UseMinimalApiFrameworkRoutes(this WebApplication webApplication)
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
    private static string BuildInternal(ReadOnlySpan<RouteMappingResult> endpointRouteMappings)
    {
        StringBuilder builder = new();
        RouteMappingResult[] mappingsArray = endpointRouteMappings.ToArray();
        ReadOnlySpan<(int Version, string ClassName, string FullName)> versionWithClassNames = mappingsArray
                                                                         .Select(mapping => (mapping.Version, JsonNamingPolicy.CamelCase.ConvertName(mapping.ClassName), $"{mapping.Namespace}.{mapping.ClassName}"))
                                                                         .Distinct()
                                                                         .ToArray();

        ReadOnlySpan<int> distinctVersions = mappingsArray.Select(mapping => mapping.Version).Distinct().ToArray();

        foreach (int version in distinctVersions)
        {
            builder.Append("\t\tRouteGroupBuilder apiVersionRouteV");
            builder.Append(version);
            builder.Append(" = webApplication.GetApiVersionRoute(");
            builder.Append(version);
            builder.AppendLine(");");
        }
        builder.AppendLine();

        foreach ((int Version, string ClassName, string FullName) versionWithName in versionWithClassNames)
        {
            builder.Append("\t\t");
            builder.Append(versionWithName.FullName);
            builder.Append(" ");
            builder.Append(versionWithName.ClassName);
            builder.Append("V");
            builder.Append(versionWithName.Version);
            builder.AppendLine(" = new();");
        }

        builder.AppendLine();

        foreach (RouteMappingResult endpointRouteMapping in endpointRouteMappings)
        {
            int version = endpointRouteMapping.Version;
            builder.Append("\t\t");
            builder.Append(JsonNamingPolicy.CamelCase.ConvertName(endpointRouteMapping.ClassName));
            builder.Append("V");
            builder.Append(version);
            builder.Append(".Map");
            builder.Append(endpointRouteMapping.OperationType);
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