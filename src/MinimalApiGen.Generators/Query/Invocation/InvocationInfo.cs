using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MinimalApiGen.Generators.Query.Invocation;

/// <summary>
/// 
/// </summary>
/// <param name="invocation"></param>
/// <param name="methodSymbol"></param>
internal readonly struct InvocationInfo(InvocationExpressionSyntax invocation, IMethodSymbol methodSymbol)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public readonly InvocationExpressionSyntax Invocation = invocation;

    /// <summary>
    /// 
    /// </summary>
    public readonly IMethodSymbol MethodSymbol = methodSymbol;

    #endregion
}