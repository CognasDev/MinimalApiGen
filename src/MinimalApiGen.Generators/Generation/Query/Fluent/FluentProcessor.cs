using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query.FluentHandlers;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Fluent;
using MinimalApiGen.Generators.Generation.Shared.FluentHandlers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Generation.Query.Fluent;

/// <summary>
/// 
/// </summary>
internal static class FluentProcessor
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static EquatableArray<QueryResult> GetQueryResults(GeneratorAttributeSyntaxContext context)
    {
        ConstructorDeclarationSyntax constructor = GetConstructor(context);
        ReadOnlySpan<StatementSyntax> statements = constructor.Body!.Statements.ToArray();
        SemanticModel semanticModel = context.SemanticModel;
        List<QueryIntermediateResult> intermediateResults = [];

        foreach (StatementSyntax statement in statements)
        {
            ImmutableArray<InvocationInfo> queryInvocations = GetQueryInvocations(statement, semanticModel);
            if (queryInvocations.Length > 0)
            {
                InvocationResult invocationResult = queryInvocations.ToInvocationResult();
                ReadOnlySpan<FluentMethodInfo> fluentMethods = queryInvocations.ToFluentMethodInfos();

                QueryIntermediateResult? intermediateResult = null;
                string queryNamespace = string.Empty;

                foreach (FluentMethodInfo fluentMethod in fluentMethods)
                {
                    InvocationInfo invocationInfo = fluentMethod.Invocation;
                    switch (fluentMethod.FullyQualifiedName)
                    {
                        case string name when name == FullyQualifiedMethodNames.WithNamespace:
                            queryNamespace = invocationInfo.ToNamespace(semanticModel);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithNamespaceOf:
                            queryNamespace = invocationInfo.ToNamespace();
                            break;
                        case string name when (name == FullyQualifiedMethodNames.WithGetBusinessLogic || name == FullyQualifiedMethodNames.WithGetByIdBusinessLogic)
                                              && fluentMethod.IsGeneric:
                            intermediateResult!.BusinessLogicResult = invocationInfo.ToBusinessLogic();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithGet:
                            intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace);
                            intermediateResult = invocationResult.InitialiseQueryIntermediateResult(QueryType.Get);
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithGetById:
                            intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace);
                            intermediateResult = invocationResult.InitialiseQueryIntermediateResult(QueryType.GetById);
                            break;
                        case string name when (name == FullyQualifiedMethodNames.WithGetServices || name == FullyQualifiedMethodNames.WithGetByIdServices)
                                              && fluentMethod.IsGeneric:
                            IReadOnlyList<string> services = invocationInfo.ToServices();
                            intermediateResult!.Services.AddRange(services);
                            break;
                        case string name when (name == FullyQualifiedMethodNames.WithGetKeyedServices || name == FullyQualifiedMethodNames.WithGetByIdKeyedServices)
                                              && fluentMethod.IsGeneric:
                            Dictionary<string, string> keyedServices = invocationInfo.ToKeyedServices(semanticModel);
                            intermediateResult!.KeyedServices.AddRange(keyedServices);
                            break;
                        case string name when (name == FullyQualifiedMethodNames.WithGetResponse || name == FullyQualifiedMethodNames.WithGetByIdResponse)
                                              && fluentMethod.IsGeneric:
                            intermediateResult!.ResponseResult = invocationInfo.ToResponse();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithMappingService:
                            intermediateResult!.WithMappingService = true;
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithPagination:
                            intermediateResult!.WithPagination = true;
                            break;
                        case string name when name == FullyQualifiedMethodNames.CachedFor:
                            intermediateResult!.CachedFor = invocationInfo.GetCachedForTimeSpan();
                            break;
                        case string name when name == FullyQualifiedMethodNames.WithVersion:
                            int version = invocationInfo.ToVersion(semanticModel);
                            intermediateResult!.Version = version;
                            break;
                    }
                }

                intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace);
            }
        }

        return BuildQueryResults(intermediateResults);
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
    /// <returns></returns>
    private static ImmutableArray<InvocationInfo> GetQueryInvocations(StatementSyntax statement, SemanticModel semanticModel)
    {
        IReadOnlyList<InvocationExpressionSyntax> expressions = statement.DescendantNodes().OfType<InvocationExpressionSyntax>().ToList();
        bool hasQuery = expressions.Any(expression => expression.GetMethodSymbol(semanticModel)?.ConstructedFrom?.ToDisplayString() == FullyQualifiedMethodNames.Query);

        return hasQuery ?
               expressions.Select(invocationExpressionSyntax => invocationExpressionSyntax.ToInvocationInfo(semanticModel))
                          .Reverse()
                          .ToImmutableArray()
              : [];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryIntermediateResults"></param>
    /// <returns></returns>
    private static EquatableArray<QueryResult> BuildQueryResults(List<QueryIntermediateResult> queryIntermediateResults)
    {
        List<QueryResult> queryResultsBuilder = [];
        ReadOnlySpan<QueryIntermediateResult> span = [.. queryIntermediateResults];
        foreach (QueryIntermediateResult intermediateResult in span)
        {
            QueryResult queryResult = new(intermediateResult);
            queryResultsBuilder.Add(queryResult);
        }
        return new(queryResultsBuilder);
    }

    #endregion
}