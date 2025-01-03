using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.Fluent;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Query.Invocation;

/// <summary>
/// 
/// </summary>
internal static class InvocationExtensions
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    private static readonly SymbolDisplayFormat _fullyQualifiedFormat = new
        (
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.None,
            memberOptions: SymbolDisplayMemberOptions.IncludeContainingType | SymbolDisplayMemberOptions.IncludeParameters,
            parameterOptions: SymbolDisplayParameterOptions.None,
            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers
        );

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocations"></param>
    /// <returns></returns>
    public static ReadOnlySpan<FluentMethodInfo> ToFluentMethodInfos(this ImmutableArray<InvocationInfo> fluentInvocations)
    {
        return fluentInvocations
            .Select(invocationInfo => new
            {
                FullyQualifiedName = invocationInfo.ToFullyQualifiedMethodName(),
                Invocation = invocationInfo,
                IsGeneric = invocationInfo.MethodSymbol?.IsGenericMethod ?? false
            })
            .Where(info => !string.IsNullOrEmpty(info.FullyQualifiedName))
            .Select(static info => new FluentMethodInfo(info.FullyQualifiedName!, info.Invocation, info.IsGeneric))
            .ToArray()
            .AsSpan();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <returns></returns>
    public static string? ToFullyQualifiedMethodName(this InvocationInfo fluentInvocation)
    {
        string? fullyQualifiedName = fluentInvocation.MethodSymbol?.ToDisplayString(_fullyQualifiedFormat).TrimEnd('(', ')');
        return fullyQualifiedName;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static ITypeSymbol GetSingleGenericArgument(this InvocationInfo fluentInvocation)
        => fluentInvocation.MethodSymbol.TypeArguments.Single();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    public static ExpressionSyntax GetSingleArgumentExpression(this InvocationInfo fluentInvocation)
        => fluentInvocation.Invocation.ArgumentList.Arguments.Single().Expression;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fluentInvocation"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    public static TReturn GetSingleArgumentValue<TReturn>(this InvocationInfo fluentInvocation, SemanticModel semanticModel)
    {
        ExpressionSyntax parameterExpressionSyntax = fluentInvocation.GetSingleArgumentExpression();
        TReturn returnValue = (TReturn)semanticModel.GetConstantValue(parameterExpressionSyntax).Value!;
        return returnValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeSymbol"></param>
    /// <returns></returns>
    public static IReadOnlyList<string> GetPublicProperties(this ITypeSymbol typeSymbol)
    {
        List<string> properties = typeSymbol.GetMembers()
                                            .OfType<IPropertySymbol>()
                                            .Where(property => property.DeclaredAccessibility == Accessibility.Public)
                                            .Select(property => property.Name)
                                            .ToList();
        return properties;
    }

    #endregion
}