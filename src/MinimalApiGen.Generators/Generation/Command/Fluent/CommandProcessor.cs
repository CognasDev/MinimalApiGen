﻿using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.FluentHandlers;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Fluent;
using MinimalApiGen.Generators.Generation.Shared.FluentHandlers;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MinimalApiGen.Generators.Generation.Command.Fluent;

/// <summary>
/// 
/// </summary>
internal sealed class CommandProcessor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandInvocations"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static EquatableArray<IResult> GetCommandResults(ImmutableArray<InvocationInfo> commandInvocations, SemanticModel semanticModel)
    {
        InvocationResult invocationResult = commandInvocations.ToInvocationResult();
        ReadOnlySpan<FluentMethodInfo> fluentMethods = commandInvocations.ToFluentMethodInfos();
        List<CommandIntermediateResult> intermediateResults = [];

        CommandIntermediateResult? intermediateResult = null;
        ModelIdPropertyResult modelIdPropertyResult = default;
        string commandNamespace = string.Empty;

        foreach (FluentMethodInfo fluentMethod in fluentMethods)
        {
            InvocationInfo invocationInfo = fluentMethod.Invocation;
            switch (fluentMethod.FullyQualifiedName)
            {
                case string name when name == CommandMethodNames.WithNamespace:
                    commandNamespace = invocationInfo.ToNamespace(semanticModel);
                    break;
                case string name when name == CommandMethodNames.WithNamespaceOf:
                    commandNamespace = invocationInfo.ToNamespace();
                    break;
                case string name when name == CommandMethodNames.WithModelId:
                    modelIdPropertyResult = invocationInfo.ToModelIdPropertyName(semanticModel);
                    break;
                case string name when (name == CommandMethodNames.WithPostHandler || name == CommandMethodNames.WithPutHandler || name == CommandMethodNames.WithDeleteHandler) && fluentMethod.IsGeneric:
                    intermediateResult!.HandlerResult = invocationInfo.ToHandler();
                    break;
                case string name when name == CommandMethodNames.WithPost:
                    intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace, modelIdPropertyResult);
                    intermediateResult = invocationResult.InitialiseCommandIntermediateResult(OperationType.Post);
                    break;
                case string name when name == CommandMethodNames.WithPut:
                    intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace, modelIdPropertyResult);
                    intermediateResult = invocationResult.InitialiseCommandIntermediateResult(OperationType.Put);
                    break;
                case string name when name == CommandMethodNames.WithDelete:
                    intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace, modelIdPropertyResult);
                    intermediateResult = invocationResult.InitialiseCommandIntermediateResult(OperationType.Delete);
                    break;
                case string name when (name == CommandMethodNames.WithPostServices || name == CommandMethodNames.WithPutServices || name == CommandMethodNames.WithDeleteServices) && fluentMethod.IsGeneric:
                    IReadOnlyList<string> services = invocationInfo.ToServices();
                    intermediateResult!.Services.AddRange(services);
                    break;
                case string name when (name == CommandMethodNames.WithPostKeyedServices || name == CommandMethodNames.WithPutKeyedServices || name == CommandMethodNames.WithDeleteKeyedServices) && fluentMethod.IsGeneric:
                    Dictionary<string, string> keyedServices = invocationInfo.ToKeyedServices(semanticModel);
                    intermediateResult!.KeyedServices.AddRange(keyedServices);
                    break;
                case string name when (name == CommandMethodNames.WithPostRequest || name == CommandMethodNames.WithPutRequest || name == CommandMethodNames.WithDeleteRequest) && fluentMethod.IsGeneric:
                    intermediateResult!.RequestResult = invocationInfo.ToRequest();
                    break;
                case string name when (name == CommandMethodNames.WithPostResponse || name == CommandMethodNames.WithPutResponse) && fluentMethod.IsGeneric:
                    intermediateResult!.ResponseResult = invocationInfo.ToResponse();
                    break;
                case string name when (name == CommandMethodNames.WithPostFluentValidation || name == CommandMethodNames.WithPutFluentValidation):
                    intermediateResult!.WithFluentValidation = true;
                    break;
                case string name when name == CommandMethodNames.WithRequestMappingService:
                    intermediateResult!.WithRequestMappingService = true;
                    break;
                case string name when name == CommandMethodNames.WithResponseMappingService:
                    intermediateResult!.WithResponseMappingService = true;
                    break;
                case string name when name == CommandMethodNames.WithVersion:
                    int version = invocationInfo.ToVersion(semanticModel);
                    intermediateResult!.Version = version;
                    break;
                case string name when (name == CommandMethodNames.WithPostJwtAuthentication || name == CommandMethodNames.WithPutJwtAuthentication || name == CommandMethodNames.WithDeleteJwtAuthentication):
                    intermediateResult!.WithJwtAuthentication = true;
                    intermediateResult.AuthenticationRole = invocationInfo.ToAuthenticationRole(semanticModel);
                    break;
                case string name when (name == CommandMethodNames.WithPostAddEndpontFilter || name == CommandMethodNames.WithPutAddEndpontFilter || name == CommandMethodNames.WithDeleteAddEndpontFilter):
                    intermediateResult!.AddEndpointFilterResult = invocationInfo.ToEndpointFilter();
                    break;
            }
        }

        intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, commandNamespace, modelIdPropertyResult!);

        return BuildCommandResults(intermediateResults);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandIntermediateResults"></param>
    /// <returns></returns>
    private static EquatableArray<IResult> BuildCommandResults(List<CommandIntermediateResult> commandIntermediateResults)
    {
        List<IResult> commandResultsBuilder = [];
        ReadOnlySpan<CommandIntermediateResult> span = [.. commandIntermediateResults];
        foreach (CommandIntermediateResult intermediateResult in span)
        {
            CommandResult commandResult = new(intermediateResult);
            commandResultsBuilder.Add(commandResult);
        }
        return new(commandResultsBuilder);
    }

    #endregion
}