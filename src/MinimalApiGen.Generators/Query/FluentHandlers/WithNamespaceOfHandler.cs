using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.Query.Invocation;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithNamespaceOfHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static string ToNamespace(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol typeSymbol = fluentInvocation.GetSingleGenericArgument();
        string containingNamespace = typeSymbol.ContainingNamespace.ToDisplayString();
        return containingNamespace;
    }

    #endregion
}