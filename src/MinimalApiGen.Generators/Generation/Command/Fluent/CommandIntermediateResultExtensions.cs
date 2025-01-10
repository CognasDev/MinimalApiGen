using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
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
    public static CommandIntermediateResult InitialiseCommandIntermediateResult(this InvocationResult commandInvocationDetails, CommandType commandType)
    {
        CommandIntermediateResult result = new()
        {
            ModelFullyQualifiedName = commandInvocationDetails.ModelFullyQualifiedName,
            ModelPluralName = commandInvocationDetails.ModelPluralName,
            ModelName = commandInvocationDetails.ModelName,
            CommandType = commandType
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
    /// <param name="modelIdPropertyName"></param>
    public static void TryFinaliseAndCollectIntermediateResult(this List<CommandIntermediateResult> commandIntermediateResults,
                                                               CommandIntermediateResult? commandIntermediateResult,
                                                               string commandNamespace,
                                                               string modelIdPropertyName)
    {
        if (commandIntermediateResult is not null)
        {
            commandIntermediateResult.CommandNamespace = commandNamespace;
            commandIntermediateResult.ModelIdPropertyName = modelIdPropertyName;
            commandIntermediateResults.Add(commandIntermediateResult);
        }
    }

    #endregion
}