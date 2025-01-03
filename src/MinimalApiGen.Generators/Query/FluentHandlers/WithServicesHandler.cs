using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Query.Invocation;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithServicesHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static IReadOnlyList<string> ToServices(this InvocationInfo fluentInvocation)
    {
        ImmutableArray<ITypeSymbol> serviceTypeSymbols = fluentInvocation.MethodSymbol.TypeArguments;
        List<string> serviceFullyQualifiedNames = [];
        foreach (ITypeSymbol serviceTypeSymbol in serviceTypeSymbols)
        {
            string serviceFullyQualifiedName = serviceTypeSymbol.ToDisplayString();
            serviceFullyQualifiedNames.Add(serviceFullyQualifiedName);
        }
        return serviceFullyQualifiedNames;
    }

    #endregion
}