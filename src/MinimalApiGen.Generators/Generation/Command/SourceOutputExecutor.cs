using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Command.SourceBuilders;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Command;

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
    /// <param name="commandResults"></param>
    public static void Execute(SourceProductionContext context, ImmutableArray<CommandResult> commandResults)
    {
        ReadOnlySpan<CommandResult> span = commandResults.AsSpan();
        foreach (CommandResult commandResult in span)
        {
            ServicesBuilder servicesBuilder = new(commandResult.Services, commandResult.KeyedServices);
            switch (commandResult.CommandType)
            {
                case CommandType.Post:
                    AddPostGetSource(context, commandResult, servicesBuilder, commandResult.Version);
                    break;
                case CommandType.Put:
                    AddPutGetSource(context, commandResult, servicesBuilder, commandResult.Version);
                    break;
                case CommandType.Delete:
                    AddDeleteGetSource(context, commandResult, servicesBuilder, commandResult.Version);
                    break;
            }

            if (commandResult.WithRequestMappingService)
            {
                AddRequestMappingService(context, commandResult, commandResult.Version);
            }
            if (commandResult.WithResponseMappingService)
            {
                AddResponseMappingService(context, commandResult, commandResult.Version);
            }
        }

        ReadOnlySpan<CommandRouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(commandResults);
        string mappingExtension = CommandMappingExtensionBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.Command.g.cs", mappingExtension);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandResults"></param>
    /// <returns></returns>
    private static ReadOnlySpan<CommandRouteMappingResult> GetEndpointRouteMappings(ImmutableArray<CommandResult> commandResults)
    {
        return commandResults
            .Select
             (
                commandResult => new CommandRouteMappingResult
                {
                    ClassName = commandResult.ClassName,
                    ClassNamespace = commandResult.ClassNamespace,
                    Version = commandResult.Version,
                    CommandType = commandResult.CommandType
                }
             )
            .Distinct()
            .ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddPostGetSource(SourceProductionContext context, CommandResult commandResult, ServicesBuilder servicesBuilder, int apiVersion)
    {
        MapPostBuilder builder = new(commandResult, apiVersion, servicesBuilder);
        string mapPost = builder.Build();
        context.AddSource($"{commandResult.ModelFullyQualifiedName}.PostV{apiVersion}.g.cs", mapPost);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddPutGetSource(SourceProductionContext context, CommandResult commandResult, ServicesBuilder servicesBuilder, int apiVersion)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="servicesBuilder"></param>
    /// <param name="apiVersion"></param>
    private static void AddDeleteGetSource(SourceProductionContext context, CommandResult commandResult, ServicesBuilder servicesBuilder, int apiVersion)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddRequestMappingService(SourceProductionContext context, CommandResult commandResult, int apiVersion)
    {
        string operationName = commandResult.CommandType.ToString();
        string mappingServiceName = BuildMappingServiceName(commandResult.RequestName, commandResult.ModelName, operationName, apiVersion);
        CommandRequestMappingServiceBuilder builder = new(commandResult);
        string mappingService = builder.Build();
        context.AddSource(mappingServiceName, mappingService);

        string mappingServiceDependency = MappingServicesBuilder.Build(commandResult.RequestFullyQualifiedName, commandResult.ModelFullyQualifiedName, commandResult.ClassNamespace, builder.MappingServiceName);
        context.AddSource(mappingServiceName.Replace("g.cs","Dep.g.cs"), mappingServiceDependency);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddResponseMappingService(SourceProductionContext context, CommandResult commandResult, int apiVersion)
    {
        string operationName = commandResult.CommandType.ToString();
        string mappingServiceName = BuildMappingServiceName(commandResult.ModelName, commandResult.ResponseName, operationName, apiVersion);
        CommandResponseMappingServiceBuilder builder = new(commandResult);
        string mappingService = builder.Build();
        context.AddSource(mappingServiceName, mappingService);

        string mappingServiceDependency = MappingServicesBuilder.Build(commandResult.ModelFullyQualifiedName, commandResult.ResponseFullyQualifiedName, commandResult.ClassNamespace, builder.MappingServiceName);
        context.AddSource(mappingServiceName.Replace("g.cs", "Dep.g.cs"), mappingServiceDependency);
    }

    #endregion
}