using Microsoft.CodeAnalysis;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

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