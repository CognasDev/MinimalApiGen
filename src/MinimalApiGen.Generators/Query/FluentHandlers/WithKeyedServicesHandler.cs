using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.Invocation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Query.FluentHandlers;

/// <summary>
/// 
/// </summary>
internal static class WithKeyedServicesHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ToKeyedServices(this InvocationInfo fluentInvocation, SemanticModel semanticModel)
    {
        ImmutableArray<ITypeSymbol> serviceTypeSymbols = fluentInvocation.MethodSymbol.TypeArguments;
        ReadOnlySpan<ArgumentSyntax> serviceKeys = [.. fluentInvocation.InvocationExpressionSyntax.ArgumentList.Arguments];
        Dictionary<string, string> keyedServices = [];
        for (int index = 0; index < serviceTypeSymbols.Length; index++)
        {
            ExpressionSyntax expression = serviceKeys[index].Expression;
            string serviceKey = GetServiceKey(expression, semanticModel);
            string serviceFullyQualifiedName = serviceTypeSymbols[index].ToDisplayString();
            keyedServices.Add(serviceKey, serviceFullyQualifiedName);
        }
        return keyedServices;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="keyValuePairs"></param>
    public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
                                              IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
    {
        foreach (KeyValuePair<TKey, TValue> keyValuePair in keyValuePairs)
        {
            dictionary[keyValuePair.Key] = keyValuePair.Value;
        }
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    /// <exception cref="InvalidProgramException"></exception>
    private static string GetServiceKey(ExpressionSyntax expression, SemanticModel semanticModel)
    {
        string serviceKey = IsNameOf(expression) is IdentifierNameSyntax identifierName
                            ? identifierName.Identifier.Text
                            : semanticModel.GetConstantValue(expression).Value!.ToString();

        if (!SyntaxFacts.IsValidIdentifier(serviceKey))
        {
            throw new InvalidProgramException($"The service key '{serviceKey}' is not a valid .NET identifier.");
        }

        return serviceKey;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    private static IdentifierNameSyntax? IsNameOf(ExpressionSyntax expression)
    {
        if (expression is InvocationExpressionSyntax { Expression: IdentifierNameSyntax { Identifier.Text: "nameof" } } invocationExpression)
        {
            return (IdentifierNameSyntax)invocationExpression.ArgumentList.Arguments[0].Expression;
        }
        return null;
    }

    #endregion
}