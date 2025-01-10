using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Shared.Fluent;

/// <summary>
/// 
/// </summary>
internal abstract class ProcessorBase
{
    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    protected ProcessorBase()
    {
    }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    protected static ConstructorDeclarationSyntax GetConstructor(GeneratorAttributeSyntaxContext context)
    {
        ClassDeclarationSyntax classDeclarationSyntax = (ClassDeclarationSyntax)context.TargetNode;
        return classDeclarationSyntax.Members.OfType<ConstructorDeclarationSyntax>().Single();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statement"></param>
    /// <param name="semanticModel"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    protected static ImmutableArray<InvocationInfo> GetInvocations(StatementSyntax statement, SemanticModel semanticModel, string name)
    {
        IReadOnlyList<InvocationExpressionSyntax> expressions = statement.DescendantNodes().OfType<InvocationExpressionSyntax>().ToList();
        bool hasInvocation = expressions.Any(expression => expression.GetMethodSymbol(semanticModel)?.ConstructedFrom?.ToDisplayString() == name);

        return hasInvocation ?
               expressions.Select(invocationExpressionSyntax => invocationExpressionSyntax.ToInvocationInfo(semanticModel))
                          .Reverse()
                          .ToImmutableArray()
              : [];
    }

    #endregion
}