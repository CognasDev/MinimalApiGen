using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithHandlerHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static HandlerResult ToHandler(this InvocationInfo fluentInvocation)
    {
        ITypeSymbol handlerTypeSymbol = fluentInvocation.GetSingleGenericArgument();
        SimpleLambdaExpressionSyntax lambdaExpression = (SimpleLambdaExpressionSyntax)fluentInvocation.GetSingleArgumentExpression();
        string delegateName = lambdaExpression.ExpressionBody?.TryGetInferredMemberName() ?? throw new NullReferenceException();
        IMethodSymbol methodSymbol = handlerTypeSymbol.GetAllMembers().OfType<IMethodSymbol>().Single(method => method.Name == delegateName);
        HandlerResult result = new()
        {
            FullyQualifiedName = handlerTypeSymbol.ToDisplayString(),
            DelegateName = delegateName,
        };
        foreach (IParameterSymbol parameterSymbol in methodSymbol.Parameters)
        {
            HandlerParamterResult parameterResult = new()
            {
                Name = parameterSymbol.Name,
                Type = parameterSymbol.Type.ToDisplayString(),
            };
            result.Parameters.Add(parameterResult);
        }
        return result;
    }

    #endregion
}