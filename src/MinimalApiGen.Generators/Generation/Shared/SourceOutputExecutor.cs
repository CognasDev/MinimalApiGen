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
                string mappingServiceName = BuildMappingServiceName(result.ModelName, result.ResponseName, result.ApiVersion);
                if (!mappingServiceNames.Contains(mappingServiceName))
                {
                    mappingServiceNames.Add(mappingServiceName);
                    ResponseMappingServiceBuilder builder = new(result);
                    string mappingService = builder.Build();
                    context.AddSource(mappingServiceName, mappingService);
                    string registration = BuildMappingServiceRegistration(result.ModelFullyQualifiedName, result.ResponseFullyQualifiedName, result.ClassNamespace, builder.MappingServiceName);
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
                    string registration = BuildMappingServiceRegistration(commandResult.RequestFullyQualifiedName, commandResult.ModelFullyQualifiedName, commandResult.ClassNamespace, builder.MappingServiceName);
                    registrationsBuilder.AppendLine(registration);
                }
            }
        }

        ReadOnlySpan<RouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(results);
        string mappingExtension = CommandMappingExtensionBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.g.cs", mappingExtension);

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
    /// <param name="commandResults"></param>
    /// <returns></returns>
    private static ReadOnlySpan<RouteMappingResult> GetEndpointRouteMappings(ImmutableArray<IResult> commandResults)
    {
        return commandResults
            .Select
             (
                commandResult => new RouteMappingResult
                {
                    ClassName = commandResult.ClassName,
                    ClassNamespace = commandResult.ClassNamespace,
                    Version = commandResult.ApiVersion,
                    OperationType = commandResult.OperationType
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
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    private static void AddDeleteGetSource(SourceProductionContext context, ICommandResult commandResult, ServicesBuilder servicesBuilder)
    {
        throw new NotImplementedException();
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

    #endregion
}