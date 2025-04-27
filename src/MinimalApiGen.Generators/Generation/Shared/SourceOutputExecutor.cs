using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Command.SourceBuilders;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Query.SourceBuilders;
using MinimalApiGen.Generators.Generation.Shared.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Shared;

/// <summary>
/// 
/// </summary>
internal sealed class SourceOutputExecutor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="results"></param>
    public static void Execute(SourceProductionContext context, ImmutableArray<IResult> results)
    {
        ReadOnlySpan<IResult> span = results.AsSpan();
        StringBuilder registrationsBuilder = new();
        List<string> mappingServiceNames = [];

        foreach (IResult result in span)
        {
            ServicesBuilder servicesBuilder = new(result.Services, result.KeyedServices);
            IQueryResult? queryResult = result.OperationType == OperationType.Get || result.OperationType == OperationType.GetById ? (IQueryResult)result : null;
            ICommandResult? commandResult = queryResult is null ? (ICommandResult)result : null;

            switch (result.OperationType)
            {
                case OperationType.Get:
                    AddMapGetSource(context, queryResult!, servicesBuilder);
                    break;
                case OperationType.GetById:
                    AddMapGetByIdSource(context, queryResult!, servicesBuilder);
                    break;
                case OperationType.Post:
                    AddPostGetSource(context, commandResult!, servicesBuilder);
                    break;
                case OperationType.Put:
                    AddPutGetSource(context, commandResult!, servicesBuilder);
                    break;
                case OperationType.Delete:
                    AddDeleteGetSource(context, commandResult!, servicesBuilder);
                    break;
                default:
                    throw new NotSupportedException(result.OperationType.ToString());
            }

            if (queryResult?.WithResponseMappingService == true || commandResult?.WithResponseMappingService == true)
            {
                string mappingServiceName = BuildMappingServiceName(result.ModelName, result.ResponseName!, result.ApiVersion);
                if (!mappingServiceNames.Contains(mappingServiceName))
                {
                    mappingServiceNames.Add(mappingServiceName);
                    ResponseMappingServiceBuilder builder = new(result);
                    string mappingService = builder.Build();
                    context.AddSource(mappingServiceName, mappingService);
                    string registration = BuildMappingServiceRegistration(result.ModelFullyQualifiedName, result.ResponseFullyQualifiedName!, result.Namespace, builder.MappingServiceName);
                    registrationsBuilder.AppendLine(registration);
                }
            }
            if (commandResult?.WithRequestMappingService == true)
            {
                string mappingServiceName = BuildMappingServiceName(commandResult.RequestName, commandResult.ModelName, commandResult.ApiVersion);
                if (!mappingServiceNames.Contains(mappingServiceName))
                {
                    mappingServiceNames.Add(mappingServiceName);
                    CommandRequestMappingServiceBuilder builder = new(commandResult);
                    string mappingService = builder.Build();
                    context.AddSource(mappingServiceName, mappingService);
                    string registration = BuildMappingServiceRegistration(commandResult.RequestFullyQualifiedName, commandResult.ModelFullyQualifiedName, commandResult.Namespace, builder.MappingServiceName);
                    registrationsBuilder.AppendLine(registration);
                }
            }
        }

        ReadOnlySpan<RouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(results);
        string mappingExtension = MappingExtensionsBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.g.cs", mappingExtension);

        ReadOnlySpan<string> authenticationRoles = GetAuthenticationRoles(results);
        string authenticationRolesSource = AuthenticationRolesBuilder.Build(authenticationRoles);
        context.AddSource($"AuthorizationAuthenticationRoles.g.cs", authenticationRolesSource);

        string addMinimalApiFramework = BuildAddMinimalApiFramework(results, mappingServiceNames);
        context.AddSource($"AddMinimalApiFramework.g.cs", addMinimalApiFramework);

        string useMinimalApiFramework = BuildUseMinimalApiFramework(results);
        context.AddSource($"UseMinimalApiFramework.g.cs", useMinimalApiFramework);

        string registrations = registrationsBuilder.ToString();
        if (!string.IsNullOrEmpty(registrations))
        {
            string registrationsSource = MappingRegistrationsBuilder.Build(registrations);
            context.AddSource($"MappingRegistrations.g.cs", registrationsSource);
        }
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    private static string BuildMappingServiceName(string source, string target, int apiVersion) => $"{source}.{target}.MappingServiceV{apiVersion}.g.cs";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    private static ReadOnlySpan<RouteMappingResult> GetEndpointRouteMappings(ImmutableArray<IResult> results)
    {
        return results
            .Select
             (
                result => new RouteMappingResult
                {
                    ClassName = result.ClassName,
                    Namespace = result.Namespace,
                    Version = result.ApiVersion,
                    OperationType = result.OperationType
                }
             )
            .Distinct()
            .ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    private static ReadOnlySpan<string> GetAuthenticationRoles(ImmutableArray<IResult> results)
    {
        return results
            .Where(result => result.WithJwtAuthentication)
            .Select(result => result.AuthenticationRole)
            .Where(role => !string.IsNullOrWhiteSpace(role))
            .Distinct()
            .ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddMapGetSource(SourceProductionContext context, IQueryResult queryResult, ServicesBuilder servicesBuilder)
    {
        MapGetBuilder builder = new(queryResult, servicesBuilder);
        string mapGet = builder.Build();
        context.AddSource($"{queryResult.ModelFullyQualifiedName}.GetV{queryResult.ApiVersion}.g.cs", mapGet);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="queryResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddMapGetByIdSource(SourceProductionContext context, IQueryResult queryResult, ServicesBuilder servicesBuilder)
    {
        MapGetByIdBuilder builder = new(queryResult, servicesBuilder);
        string mapGet = builder.Build();
        context.AddSource($"{queryResult.ModelFullyQualifiedName}.GetByIdV{queryResult.ApiVersion}.g.cs", mapGet);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddPostGetSource(SourceProductionContext context, ICommandResult commandResult, ServicesBuilder servicesBuilder)
    {
        MapPostBuilder builder = new(commandResult, servicesBuilder);
        string mapPost = builder.Build();
        context.AddSource($"{commandResult.ModelFullyQualifiedName}.PostV{commandResult.ApiVersion}.g.cs", mapPost);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddPutGetSource(SourceProductionContext context, ICommandResult commandResult, ServicesBuilder servicesBuilder)
    {
        MapPutBuilder builder = new(commandResult, servicesBuilder);
        string mapPut = builder.Build();
        context.AddSource($"{commandResult.ModelFullyQualifiedName}.PutV{commandResult.ApiVersion}.g.cs", mapPut);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddDeleteGetSource(SourceProductionContext context, ICommandResult commandResult, ServicesBuilder servicesBuilder)
    {
        MapDeleteBuilder builder = new(commandResult, servicesBuilder);
        string mapDelete = builder.Build();
        context.AddSource($"{commandResult.ModelFullyQualifiedName}.DeleteV{commandResult.ApiVersion}.g.cs", mapDelete);
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
        string registration = SourceBuilders.MappingServiceSingletonBuilder.Build(source, target, mappingServiceFullyQualifiedName);
        return registration;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    /// <param name="mappingServiceNames"></param>
    /// <returns></returns>
    private static string BuildAddMinimalApiFramework(ImmutableArray<IResult> results, List<string> mappingServiceNames)
    {
        IQueryResult[] queryResults = [.. results.Where(result => result is IQueryResult).Select(result => (IQueryResult)result)];
        ICommandResult[] commandResults = [.. results.Where(result => result is ICommandResult).Select(result => (ICommandResult)result)];

        bool hasCommandResults = commandResults.Any();
        bool hasQueryResults = queryResults.Any();
        bool withJwtAuthentication = results.Any(result => result.WithJwtAuthentication);
        bool withPagination = queryResults.Any(queryResult => queryResult.WithPagination);
        bool withCaching = queryResults.Any(queryResult => !string.IsNullOrWhiteSpace(queryResult.CachedFor));
        bool withMappingServices = mappingServiceNames.Any();

        string addMinimalApiFramework = AddMinimalApiFrameworkBuilder.Build(hasCommandResults, hasQueryResults, withJwtAuthentication, withPagination, withCaching, withMappingServices);
        return addMinimalApiFramework;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    private static string BuildUseMinimalApiFramework(ImmutableArray<IResult> results)
    {
        IQueryResult[] queryResults = [.. results.Where(result => result is IQueryResult).Select(result => (IQueryResult)result)];

        bool withJwtAuthentication = results.Any(result => result.WithJwtAuthentication);
        bool withCaching = queryResults.Any(queryResult => !string.IsNullOrWhiteSpace(queryResult.CachedFor));

        string useMinimalApiFramework = UseMinimalApiFrameworkBuilder.Build(withJwtAuthentication, withCaching);
        return useMinimalApiFramework;
    }

    #endregion
}