using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Command.SourceBuilders;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

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
        StringBuilder commandRegistrationsBuilder = new();
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
                CommandRequestMappingServiceBuilder builder = new(commandResult);
                AddRequestMappingService(builder, context, commandResult, commandResult.Version);
                string registration = BuildMappingServiceRegistration(commandResult.RequestFullyQualifiedName, commandResult.ModelFullyQualifiedName, commandResult.ClassNamespace, builder.MappingServiceName);
                commandRegistrationsBuilder.AppendLine(registration);
            }
            if (commandResult.WithResponseMappingService)
            {
                CommandResponseMappingServiceBuilder builder = new(commandResult);
                AddResponseMappingService(builder, context, commandResult, commandResult.Version);
                string registration = BuildMappingServiceRegistration(commandResult.ModelFullyQualifiedName, commandResult.ResponseFullyQualifiedName, commandResult.ClassNamespace, builder.MappingServiceName);
                commandRegistrationsBuilder.AppendLine(registration);
            }
        }

        ReadOnlySpan<CommandRouteMappingResult> endpointRouteMappings = GetEndpointRouteMappings(commandResults);
        string mappingExtension = CommandMappingExtensionBuilder.Build(endpointRouteMappings);
        context.AddSource($"EndpointRouteMappingExtension.Command.g.cs", mappingExtension);

        string commandRegistrations = commandRegistrationsBuilder.ToString();
        string commandRegistrationsSource = CommandMappingRegistrationsBuilder.Build(commandRegistrations);
        context.AddSource($"MappingRegistrations.Command.g.cs", commandRegistrationsSource);
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
    /// <param name="builder"></param>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddRequestMappingService(CommandRequestMappingServiceBuilder builder, SourceProductionContext context, CommandResult commandResult, int apiVersion)
    {
        string operationName = commandResult.CommandType.ToString();
        string mappingServiceName = BuildMappingServiceName(commandResult.RequestName, commandResult.ModelName, operationName, apiVersion);
        string mappingService = builder.Build();
        context.AddSource(mappingServiceName, mappingService);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="context"></param>
    /// <param name="commandResult"></param>
    /// <param name="apiVersion"></param>
    private static void AddResponseMappingService(CommandResponseMappingServiceBuilder builder, SourceProductionContext context, CommandResult commandResult, int apiVersion)
    {
        string operationName = commandResult.CommandType.ToString();
        string mappingServiceName = BuildMappingServiceName(commandResult.ModelName, commandResult.ResponseName, operationName, apiVersion);
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