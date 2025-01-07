using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Query.Invocation;
using MinimalApiGen.Generators.Generation.Query.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithBusinessLogicHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static BusinessLogicResult ToBusinessLogic(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol businessLogicTypeSymbol = fluentInvocation.GetSingleGenericArgument();
        SimpleLambdaExpressionSyntax lambdaExpression = (SimpleLambdaExpressionSyntax)fluentInvocation.GetSingleArgumentExpression();
        string delegateName = lambdaExpression.ExpressionBody?.TryGetInferredMemberName() ?? throw new NullReferenceException();
        IMethodSymbol methodSymbol = businessLogicTypeSymbol.GetMembers().OfType<IMethodSymbol>().Single(method => method.Name == delegateName);
        IEnumerable<string> parameters = methodSymbol.Parameters.Select(parameter => parameter.Type.ToDisplayString());
        BusinessLogicResult result = new()
        {
            FullyQualifiedName = businessLogicTypeSymbol.ToDisplayString(),
            DelegateName = delegateName,
        };
        result.Parameters.AddRange(parameters);
        return result;
    }

    #endregion
}