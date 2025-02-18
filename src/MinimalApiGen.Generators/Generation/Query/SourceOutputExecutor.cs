using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Query.SourceBuilders;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Query;

/// <summary>
/// 
/// </summary>
internal sealed class SourceOutputExecutor : SourceOutputExecutorBase
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
        StringBuilder queryRegistrationsBuilder = new();
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
                QueryResponseMappingServiceBuilder builder = new(queryResult);
                AddMappingService(builder, context, queryResult, queryResult.Version);
                string registration = BuildMappingServiceRegistration(queryResult.ModelFullyQualifiedName, queryResult.ResponseFullyQualifiedName, queryResult.ClassNamespace, builder.MappingServiceName);
                queryRegistrationsBuilder.AppendLine(registration);
            }
        }
        ReadOnlySpan<QueryRouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(queryResults);
        string mappingExtension = QueryMappingExtensionBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.Query.g.cs", mappingExtension);

        string queryRegistrations = queryRegistrationsBuilder.ToString();
        string queryRegistrationsSource = QueryMappingRegistrationsBuilder.Build(queryRegistrations);
        context.AddSource($"MappingRegistrations.Query.g.cs", queryRegistrationsSource);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryResults"></param>
    /// <returns></returns>
    private static ReadOnlySpan<QueryRouteMappingResult> GetEndpointRouteMappings(ImmutableArray<QueryResult> queryResults)
    {
        return queryResults
            .Select
             (
                queryResult => new QueryRouteMappingResult
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
    /// <param name="servicesBuilder"></param>
    /// <param name="cachedForBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddMapGetByIdSource(SourceProductionContext context, QueryResult queryResult, ServicesBuilder servicesBuilder, CachedForBuilder cachedForBuilder, int apiVersion)
    {
        MapGetByIdBuilder builder = new(queryResult, apiVersion, servicesBuilder, cachedForBuilder);
        string mapGet = builder.Build();
        context.AddSource($"{queryResult.ModelFullyQualifiedName}.GetByIdV{apiVersion}.g.cs", mapGet);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddMappingService(QueryResponseMappingServiceBuilder builder, SourceProductionContext context, QueryResult queryResult, int apiVersion)
    {
        string operationName = queryResult.QueryType.ToString();
        string mappingServiceName = BuildMappingServiceName(queryResult.ModelName, queryResult.ResponseName, operationName, apiVersion);
        string mappingService = builder.Build();
        context.AddSource(mappingServiceName, mappingService);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="classNamespace"></param>
    /// <param name="mappingServiceName"></param>
    /// <returns></returns>
    private static string BuildMappingServiceRegistration(string source, string target, string classNamespace, string mappingServiceName)
    {
        string mappingServiceFullyQualifiedName = $"{classNamespace}.{mappingServiceName}";
        string registration = MappingRegistrationsBuilder.Build(source, target, mappingServiceFullyQualifiedName);
        return registration;
    }

    #endregion
}