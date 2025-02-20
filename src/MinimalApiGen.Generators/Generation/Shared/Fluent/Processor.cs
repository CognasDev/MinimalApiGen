using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Fluent;
using MinimalApiGen.Generators.Generation.Query.Fluent;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Shared.Fluent;

/// <summary>
/// 
/// </summary>
internal sealed class Processor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static EquatableArray<IResult> GetResults(GeneratorAttributeSyntaxContext context)
    {
        ConstructorDeclarationSyntax constructor = GetConstructor(context);
        ReadOnlySpan<StatementSyntax> statements = constructor.Body!.Statements.ToArray();
        SemanticModel semanticModel = context.SemanticModel;
        List<IResult> results = [];

        foreach (StatementSyntax statement in statements)
        {
            ImmutableArray<InvocationInfo> commandInvocations = GetInvocations(statement, semanticModel, CommandMethodNames.Command);
            if (commandInvocations.Length > 0)
            {
                EquatableArray<IResult> commandResults = CommandProcessor.GetCommandResults(commandInvocations, semanticModel);
                results.AddRange(commandResults);
            }

            ImmutableArray<InvocationInfo> queryInvocations = GetInvocations(statement, semanticModel, QueryMethodNames.Query);
            if (queryInvocations.Length > 0)
            {
                EquatableArray<IResult> queryResults = QueryProcessor.GetQueryResults(queryInvocations, semanticModel);
                results.AddRange(queryResults);
            }
        }

        return new EquatableArray<IResult>(results);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static ConstructorDeclarationSyntax GetConstructor(GeneratorAttributeSyntaxContext context)
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
    private static ImmutableArray<InvocationInfo> GetInvocations(StatementSyntax statement, SemanticModel semanticModel, string name)
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