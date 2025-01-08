using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Query.SourceBuilders;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Query;

/// <summary>
/// 
/// </summary>
internal static class SourceOutputExecutor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResults"></param>
    public static void Execute(SourceProductionContext context, ImmutableArray<QueryResult> queryResults)
    {
        ReadOnlySpan<QueryResult> span = queryResults.AsSpan();
        foreach (QueryResult queryResult in span)
        {
            ServicesBuilder servicesBuilder = new(queryResult.Services, queryResult.KeyedServices);
            CachedForBuilder cachedForBuilder = new();
            if (queryResult.QueryType == QueryType.Get)
            {
                AddMapGetSource(context, queryResult, servicesBuilder, cachedForBuilder, queryResult.Version);
            }
            else if (queryResult.QueryType == QueryType.GetById)
            {
                AddMapGetByIdSource(context, queryResult, servicesBuilder, cachedForBuilder, queryResult.Version);
            }
            if (queryResult.WithMappingService)
            {
                AddMappingService(context, queryResult, queryResult.Version);
            }
        }
        ReadOnlySpan<EndpointRouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(queryResults);
        string mappingExtension = QueryMappingExtensionBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.Query.g.cs", mappingExtension);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryResults"></param>
    /// <returns></returns>
    private static ReadOnlySpan<EndpointRouteMappingResult> GetEndpointRouteMappings(ImmutableArray<QueryResult> queryResults)
    {
        return queryResults
            .Select
             (
                queryResult => new EndpointRouteMappingResult
                {
                    ClassName = queryResult.ClassName,
                    ClassNamespace = queryResult.ClassNamespace,
                    Version = queryResult.Version,
                    QueryType = queryResult.QueryType
                }
             )
            .Distinct()
            .ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="servicesBuilder"></param>
    /// <param name="cachedForBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddMapGetSource(SourceProductionContext context, QueryResult queryResult, ServicesBuilder servicesBuilder, CachedForBuilder cachedForBuilder, int apiVersion)
    {
        MapGetBuilder builder = new(queryResult, apiVersion, servicesBuilder, cachedForBuilder);
        string mapGet = builder.Build();
        context.AddSource($"{queryResult.ModelFullyQualifiedName}.GetV{apiVersion}.g.cs", mapGet);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddMappingService(SourceProductionContext context, QueryResult queryResult, int apiVersion)
    {
        MappingServiceBuilder builder = new(queryResult);
        string mappingService = builder.Build();
        context.AddSource($"{queryResult.ModelName}{queryResult.ResponseName}.MappingSericeV{apiVersion}.g.cs", mappingService);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="servicesBuilder"></param>
    /// <param name="cachedForBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddMapGetByIdSource(SourceProductionContext context, QueryResult queryResult, ServicesBuilder servicesBuilder, CachedForBuilder cachedForBuilder, int apiVersion)
    {
        MapGetByIdBuilder builder = new(queryResult, apiVersion, servicesBuilder, cachedForBuilder);
        string mapGet = builder.Build();
        context.AddSource($"{queryResult.ModelFullyQualifiedName}.GetByIdV{apiVersion}.g.cs", mapGet);
    }

    #endregion
}