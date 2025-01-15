using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using System;

namespace MinimalApiGen.Generators.Generation.Shared.FluentHandlers;

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

        INamedTypeSymbol typeSymbol = (INamedTypeSymbol)semanticModel.GetTypeInfo(expression).Type! ?? throw new InvalidCastException();

        string propertyType = typeSymbol.ToDisplayString();
        string underlyingType = typeSymbol.NullableAnnotation == NullableAnnotation.Annotated
                                ? typeSymbol.TypeArguments[0].ToDisplayString()
                                : propertyType;

        ModelIdPropertyResult result = new() { PropertyName = propertyName, PropertyType = propertyType, UnderlyingType = underlyingType };
        return result;
    }

    #endregion
}