using Microsoft.CodeAnalysis;
using MinimalApiGen.Framework.Pluralize;
using MinimalApiGen.Generators.Generation.Command.Fluent;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Command.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class CommandHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="invocations"></param>
    /// <returns></returns>
    public static InvocationResult ToInvocationResult(this ImmutableArray<InvocationInfo> invocations)
    {
        InvocationInfo queryInvocation = invocations.Single(invocation => invocation.MethodSymbol?.ConstructedFrom?.ToDisplayString() == CommandMethodNames.Command);
        ITypeSymbol modelSymbol = queryInvocation.MethodSymbol.TypeArguments.Single();
        IReadOnlyList<string> modelProperties = modelSymbol.GetPublicProperties();

        InvocationResult details = new()
        {
            ModelName = modelSymbol.Name,
            ModelPluralName = Pluralizer.Instance.Pluralize(modelSymbol.Name),
            ModelFullyQualifiedName = modelSymbol.ToDisplayString()
        };

        details.PropertyNames.AddRange(modelProperties);
        return details;
    }

    #endregion
}