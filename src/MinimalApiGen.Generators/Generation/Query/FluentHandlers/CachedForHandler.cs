using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Common;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class CachedForHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static string GetCachedForTimeSpan(this InvocationInfo fluentInvocation)
    {
        ExpressionSyntax parameterExpressionSyntax = fluentInvocation.GetSingleArgumentExpression();
        return parameterExpressionSyntax.ToString();
    }

    #endregion
}