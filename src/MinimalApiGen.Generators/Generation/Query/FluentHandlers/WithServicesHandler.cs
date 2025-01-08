using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Generation.Common;
using System;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

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
        ReadOnlySpan<ITypeSymbol> serviceTypeSymbols = fluentInvocation.MethodSymbol.TypeArguments.AsSpan();
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