using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MinimalApiGen.Generators.Generation.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithQueryParametersHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static IEnumerable<QueryParameterResult> ToQueryParameters(this InvocationInfo fluentInvocation)
    {
        List<QueryParameterResult> queryParameterResults = [];
        ITypeSymbol modelTypeSymbol = fluentInvocation.GetSingleGenericArgument();
        foreach (ExpressionSyntax queryParameterSyntax in fluentInvocation.GetAllArgumentExpressions())
        {
            SimpleLambdaExpressionSyntax lambdaExpression = (SimpleLambdaExpressionSyntax)queryParameterSyntax;
            string propertyName = lambdaExpression.ExpressionBody?.TryGetInferredMemberName() ?? throw new NullReferenceException();
            IPropertySymbol propertySymbol = modelTypeSymbol.GetAllMembers().OfType<IPropertySymbol>().Single(property => property.Name == propertyName);

            QueryParameterResult result = new()
            {
                Name = JsonNamingPolicy.CamelCase.ConvertName(propertyName),
                Type = propertySymbol.Type.ToDisplayString()
            };
            queryParameterResults.Add(result);
        }
        return queryParameterResults;
    }

    #endregion
}