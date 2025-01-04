using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Query.Invocation;
using MinimalApiGen.Generators.Query.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithResponseHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static WithResponseResult ToResponse(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol responseTypeSymbol = fluentInvocation.GetSingleGenericArgument();
        IReadOnlyList<string> responseProperties = responseTypeSymbol.GetPublicProperties();

        WithResponseResult result = new()
        {
            ResponseFullyQualifiedName = responseTypeSymbol.ToDisplayString(),
            ResponseName = responseTypeSymbol.Name
        };
        result.PropertyNames.AddRange(responseProperties);
        return result;
    }

    #endregion
}