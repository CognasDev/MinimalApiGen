using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MinimalApiGen.Generators.Query.Invocation;

/// <summary>
/// 
/// </summary>
/// <param name="invocationExpressionSyntax"></param>
/// <param name="methodSymbol"></param>
internal readonly struct InvocationInfo(InvocationExpressionSyntax invocationExpressionSyntax, IMethodSymbol methodSymbol)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public readonly InvocationExpressionSyntax InvocationExpressionSyntax = invocationExpressionSyntax;

    /// <summary>
    /// 
    /// </summary>
    public readonly IMethodSymbol MethodSymbol = methodSymbol;

    #endregion
}