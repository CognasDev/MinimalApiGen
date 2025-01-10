using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Command.Results;
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
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static ModelIdPropertyResult ToModelIdPropertyName(this InvocationInfo fluentInvocation, SemanticModel semanticModel)
    {
        SimpleLambdaExpressionSyntax lambdaExpression = (SimpleLambdaExpressionSyntax)fluentInvocation.GetSingleArgumentExpression();
        ExpressionSyntax expression = lambdaExpression.ExpressionBody ?? throw new NullReferenceException(nameof(SimpleLambdaExpressionSyntax.ExpressionBody));
        string propertyName = expression.TryGetInferredMemberName() ?? throw new NullReferenceException(nameof(ModelIdPropertyResult.PropertyName));

        ITypeSymbol typeSymbol = semanticModel.GetTypeInfo(expression).Type ?? throw new InvalidOperationException("Unable to determine the type of the expression body.");
        string propertyType = typeSymbol.ToDisplayString();
        bool isNullable = typeSymbol.NullableAnnotation == NullableAnnotation.Annotated;

        ModelIdPropertyResult result = new() { PropertyName = propertyName, PropertyType = propertyType, IsNullable = isNullable };
        return result;
    }

    #endregion
}