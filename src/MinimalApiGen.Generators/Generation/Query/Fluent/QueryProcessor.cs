﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Fluent;
using MinimalApiGen.Generators.Generation.Command.Results;
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
internal sealed class QueryProcessor : ProcessorBase
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
            ImmutableArray<InvocationInfo> queryInvocations = GetInvocations(statement, semanticModel, QueryMethodNames.Query);
            if (queryInvocations.Length > 0)
            {
                InvocationResult invocationResult = queryInvocations.ToInvocationResult();
                ReadOnlySpan<FluentMethodInfo> fluentMethods = queryInvocations.ToFluentMethodInfos();

                QueryIntermediateResult? intermediateResult = null;
                ModelIdPropertyResult modelIdPropertyResult = default; 
                string queryNamespace = string.Empty;

                foreach (FluentMethodInfo fluentMethod in fluentMethods)
                {
                    InvocationInfo invocationInfo = fluentMethod.Invocation;
                    switch (fluentMethod.FullyQualifiedName)
                    {
                        case string name when name == QueryMethodNames.WithNamespace:
                            queryNamespace = invocationInfo.ToNamespace(semanticModel);
                            break;
                        case string name when name == QueryMethodNames.WithNamespaceOf:
                            queryNamespace = invocationInfo.ToNamespace();
                            break;
                        case string name when name == QueryMethodNames.WithModelId:
                            modelIdPropertyResult = invocationInfo.ToModelIdPropertyName(semanticModel);
                            break;
                        case string name when (name == QueryMethodNames.WithGetBusinessLogic || name == QueryMethodNames.WithGetByIdBusinessLogic)
                                              && fluentMethod.IsGeneric:
                            intermediateResult!.BusinessLogicResult = invocationInfo.ToBusinessLogic();
                            break;
                        case string name when name == QueryMethodNames.WithGet:
                            intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace, modelIdPropertyResult);
                            intermediateResult = invocationResult.InitialiseQueryIntermediateResult(QueryType.Get);
                            break;
                        case string name when name == QueryMethodNames.WithGetById:
                            intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace, modelIdPropertyResult);
                            intermediateResult = invocationResult.InitialiseQueryIntermediateResult(QueryType.GetById);
                            break;
                        case string name when (name == QueryMethodNames.WithGetServices || name == QueryMethodNames.WithGetByIdServices)
                                              && fluentMethod.IsGeneric:
                            IReadOnlyList<string> services = invocationInfo.ToServices();
                            intermediateResult!.Services.AddRange(services);
                            break;
                        case string name when (name == QueryMethodNames.WithGetKeyedServices || name == QueryMethodNames.WithGetByIdKeyedServices)
                                              && fluentMethod.IsGeneric:
                            Dictionary<string, string> keyedServices = invocationInfo.ToKeyedServices(semanticModel);
                            intermediateResult!.KeyedServices.AddRange(keyedServices);
                            break;
                        case string name when (name == QueryMethodNames.WithGetResponse || name == QueryMethodNames.WithGetByIdResponse)
                                              && fluentMethod.IsGeneric:
                            intermediateResult!.ResponseResult = invocationInfo.ToResponse();
                            break;
                        case string name when name == QueryMethodNames.WithMappingService:
                            intermediateResult!.WithMappingService = true;
                            break;
                        case string name when name == QueryMethodNames.WithPagination:
                            intermediateResult!.WithPagination = true;
                            break;
                        case string name when name == QueryMethodNames.CachedFor:
                            intermediateResult!.CachedFor = invocationInfo.GetCachedForTimeSpan();
                            break;
                        case string name when name == QueryMethodNames.WithVersion:
                            int version = invocationInfo.ToVersion(semanticModel);
                            intermediateResult!.Version = version;
                            break;
                    }
                }

                intermediateResults.TryFinaliseAndCollectIntermediateResult(intermediateResult, queryNamespace, modelIdPropertyResult);
            }
        }

        return BuildQueryResults(intermediateResults);
    }

    #endregion

    #region Private Method Declarations

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