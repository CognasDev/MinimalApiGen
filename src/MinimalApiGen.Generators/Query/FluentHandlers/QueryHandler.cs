using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Pluralize;
using MinimalApiGen.Generators.Query.Fluent;
using MinimalApiGen.Generators.Query.Invocation;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class QueryHandler
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
    public static QueryInvocationDetails ToQueryInvocationDetails(this ImmutableArray<InvocationInfo> invocations)
    {
        InvocationInfo queryInvocation = invocations.Single(invocation => invocation.MethodSymbol?.ConstructedFrom?.ToDisplayString() == FullyQualifiedMethodNames.Query);
        ITypeSymbol modelSymbol = queryInvocation.MethodSymbol.TypeArguments.Single();
        IReadOnlyList<string> modelProperties = modelSymbol.GetPublicProperties();

        QueryInvocationDetails details = new()
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