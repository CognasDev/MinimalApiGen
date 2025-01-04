using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.FluentHandlers;
using MinimalApiGen.Generators.Query.Invocation;
using MinimalApiGen.Generators.Query.Results;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MinimalApiGen.Generators.Query.Fluent;

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
    public static ImmutableArray<QueryResult> GetQueryResults(GeneratorAttributeSyntaxContext context)
    {
        ConstructorDeclarationSyntax constructor = GetConstructor(context);
        SemanticModel semanticModel = context.SemanticModel;
        ImmutableArray<InvocationInfo> invocations = GetInvocations(constructor, semanticModel);
        QueryInvocationDetails queryInvocationDetails = invocations.ToQueryInvocationDetails();
        List<QueryIntermediateResult> intermediateResults = [];
        QueryIntermediateResult? intermediateResult = null;
        string masterNamespace = string.Empty;
        string classNamespace = string.Empty;

        ReadOnlySpan<FluentMethodInfo> fluentMethods = invocations.ToFluentMethodInfos();

        foreach (FluentMethodInfo fluentMethod in fluentMethods)
        {
            InvocationInfo invocationInfo = fluentMethod.Invocation;
            switch (fluentMethod.FullyQualifiedName)
            {
                case string name when name == FullyQualifiedMethodNames.WithGet || name == FullyQualifiedMethodNames.WithGetById:
                    intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, masterNamespace, classNamespace);
                    intermediateResult = queryInvocationDetails.InitialiseQueryIntermediateResult();
                    classNamespace = string.Empty;
                    break;
                case string name when name == FullyQualifiedMethodNames.WithNamespace:
                    string namespaceValue = invocationInfo.ToNamespace(semanticModel);
                    if (intermediateResult is null)
                    {
                        masterNamespace = namespaceValue;
                    }
                    else
                    {
                        classNamespace = namespaceValue;
                    }
                    break;
                case string name when name == FullyQualifiedMethodNames.WithNamespaceOf:
                    string strongNamespace = invocationInfo.ToNamespace();
                    if (intermediateResult is null)
                    {
                        masterNamespace = strongNamespace;
                    }
                    else
                    {
                        classNamespace = strongNamespace;
                    }
                    break;
                case string name when name == FullyQualifiedMethodNames.WithVersion:
                    int version = invocationInfo.ToVersion(semanticModel);
                    intermediateResult!.Version = version;
                    break;
                case string name when name == FullyQualifiedMethodNames.WithServices && fluentMethod.IsGeneric:
                    IReadOnlyList<string> services = invocationInfo.ToServices();
                    intermediateResult!.Services.AddRange(services);
                    break;
                case string name when name == FullyQualifiedMethodNames.WithKeyedServices && fluentMethod.IsGeneric:
                    Dictionary<string, string> keyedServices = invocationInfo.ToKeyedServices(semanticModel);
                    intermediateResult!.KeyedServices.AddRange(keyedServices);
                    break;
                case string name when name == FullyQualifiedMethodNames.WithPagination:
                    intermediateResult!.WithPagination = true;
                    break;
                case string name when name == FullyQualifiedMethodNames.WithBusinessLogic && fluentMethod.IsGeneric:
                    intermediateResult!.BusinessLogicResult = invocationInfo.ToBusinessLogic();
                    break;
                case string name when name == FullyQualifiedMethodNames.WithMappingService:
                    intermediateResult!.WithMappingService = true;
                    break;
                case string name when name == FullyQualifiedMethodNames.WithResponse && fluentMethod.IsGeneric:
                    intermediateResult!.ResponseResult = invocationInfo.ToResponse();
                    break;
                case string name when name == FullyQualifiedMethodNames.CachedFor:
                    intermediateResult!.CachedFor = invocationInfo.GetCachedForTimeSpan();
                    break;
            }
        }

        intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, masterNamespace, classNamespace);
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
    /// <remarks>
    /// Do not refactor to return <see cref="ReadOnlySpan{InvocationInfo}" /> as the ImmutableArray is consumed later by
    /// <see cref="QueryHandler.ToQueryInvocationDetails(ImmutableArray{InvocationInfo})" /> which in turn uses
    /// <see cref="System.Linq.ImmutableArrayExtensions.Single{InvocationInfo}(ImmutableArray{InvocationInfo})"/>.
    /// Single is not supported on <see cref="ReadOnlySpan{T}"/>.
    /// </remarks>
    /// <param name="constructor"></param>
    /// <param name="semanticModel"></param>
    /// <returns></returns>
    private static ImmutableArray<InvocationInfo> GetInvocations(ConstructorDeclarationSyntax constructor, SemanticModel semanticModel)
    {
        return constructor.Body!.Statements
                          .SelectMany(statement => statement.DescendantNodes().OfType<InvocationExpressionSyntax>())
                          .Select(invocationExpressionSyntax =>
                          {
                              IMethodSymbol methodSymbol = invocationExpressionSyntax.GetMethodSymbol(semanticModel);
                              return new InvocationInfo(invocationExpressionSyntax, methodSymbol);
                          })
                          .Reverse()
                          .ToImmutableArray();
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryIntermediateResults"></param>
    /// <returns></returns>
    private static ImmutableArray<QueryResult> BuildQueryResults(List<QueryIntermediateResult> queryIntermediateResults)
    {
        ImmutableArray<QueryResult>.Builder queryResultsBuilder = ImmutableArray.CreateBuilder<QueryResult>();
        ReadOnlySpan<QueryIntermediateResult> span = [.. queryIntermediateResults];
        foreach (QueryIntermediateResult intermediateResult in span)
        {
            QueryResult queryResult = new(intermediateResult);
            queryResultsBuilder.Add(queryResult);
        }
        return queryResultsBuilder.ToImmutableArray();
    }

    #endregion
}