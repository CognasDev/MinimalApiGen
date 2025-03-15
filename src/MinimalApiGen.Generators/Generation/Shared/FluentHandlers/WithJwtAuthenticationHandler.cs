using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithJwtAuthenticationHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static string? GetAuthenticationRole(this InvocationInfo fluentInvocation, SemanticModel semanticModel)
    {
        ExpressionSyntax? expression = fluentInvocation.InvocationExpressionSyntax.ArgumentList.Arguments.SingleOrDefault()?.Expression;
        if (expression is null)
        {
            return string.Empty;
        }
        string role = semanticModel.GetConstantValue(expression).Value!.ToString();
        return role;
    }

    #endregion
}