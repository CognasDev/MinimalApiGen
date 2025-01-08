using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Command.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithRequestHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static WithRequestResult ToRequest(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol requestTypeSymbol = fluentInvocation.GetSingleGenericArgument();
        IReadOnlyList<string> requestProperties = requestTypeSymbol.GetPublicProperties();

        WithRequestResult result = new()
        {
            RequestFullyQualifiedName = requestTypeSymbol.ToDisplayString(),
            RequestName = requestTypeSymbol.Name
        };
        result.PropertyNames.AddRange(requestProperties);
        return result;
    }

    #endregion
}