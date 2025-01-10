using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Shared;
using System;

namespace MinimalApiGen.Generators.Generation.Command.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithModelIdHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static string ToModelIdPropertyName(this InvocationInfo fluentInvocation)
    {
        SimpleLambdaExpressionSyntax lambdaExpression = (SimpleLambdaExpressionSyntax)fluentInvocation.GetSingleArgumentExpression();
        string delegateName = lambdaExpression.ExpressionBody?.TryGetInferredMemberName() ?? throw new NullReferenceException();
        return delegateName;
    }

    #endregion
}