﻿using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Command.Fluent;

/// <summary>
/// 
/// </summary>
internal static class CommandIntermediateResultExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandInvocationDetails"></param>
    /// <param name="commandType"></param>
    /// <returns></returns>
    public static CommandIntermediateResult InitialiseCommandIntermediateResult(this InvocationResult commandInvocationDetails, OperationType commandType)
    {
        CommandIntermediateResult result = new()
        {
            ModelFullyQualifiedName = commandInvocationDetails.ModelFullyQualifiedName,
            ModelPluralName = commandInvocationDetails.ModelPluralName,
            ModelName = commandInvocationDetails.ModelName,
            OperationType = commandType
        };
        result.ModelProperties.AddRange(commandInvocationDetails.PropertyNames);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandIntermediateResults"></param>
    /// <param name="commandIntermediateResult"></param>
    /// <param name="commandNamespace"></param>
    /// <param name="modelIdPropertyResult"></param>
    public static void TryFinaliseAndCollectIntermediateResult(this List<CommandIntermediateResult> commandIntermediateResults,
                                                               CommandIntermediateResult? commandIntermediateResult,
                                                               string commandNamespace,
                                                               ModelIdPropertyResult modelIdPropertyResult)
    {
        if (commandIntermediateResult is not null)
        {
            commandIntermediateResult.Namespace = commandNamespace;
            commandIntermediateResult.ModelIdPropertyResult = modelIdPropertyResult;
            commandIntermediateResults.Add(commandIntermediateResult);
        }
    }

    #endregion
}