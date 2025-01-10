using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Command.Fluent;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Pluralize;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Command.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class CommandHandler
{
    #region Field Declarations

    private static readonly Pluralizer _pluralizer = new();

    #endregion

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
            ModelPluralName = _pluralizer.Pluralize(modelSymbol.Name),
            ModelFullyQualifiedName = modelSymbol.ToDisplayString()
        };

        details.PropertyNames.AddRange(modelProperties);
        return details;
    }

    #endregion
}