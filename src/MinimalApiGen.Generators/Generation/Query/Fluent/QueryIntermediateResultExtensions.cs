﻿using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Query.Fluent;

/// <summary>
/// 
/// </summary>
internal static class QueryIntermediateResultExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryInvocationDetails"></param>
    /// <param name="operationType"></param>
    /// <returns></returns>
    public static QueryIntermediateResult InitialiseQueryIntermediateResult(this InvocationResult queryInvocationDetails, OperationType operationType)
    {
        QueryIntermediateResult result = new()
        {
            ModelFullyQualifiedName = queryInvocationDetails.ModelFullyQualifiedName,
            ModelPluralName = queryInvocationDetails.ModelPluralName,
            ModelName = queryInvocationDetails.ModelName,
            OperationType = operationType
        };
        result.ModelProperties.AddRange(queryInvocationDetails.PropertyNames);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryIntermediateResults"></param>
    /// <param name="queryIntermediateResult"></param>
    /// <param name="queryNamespace"></param>
    /// <param name="modelIdPropertyResult"></param>
    public static void TryFinaliseAndCollectIntermediateResult(this List<QueryIntermediateResult> queryIntermediateResults,
                                                               QueryIntermediateResult? queryIntermediateResult,
                                                               string queryNamespace,
                                                               ModelIdPropertyResult modelIdPropertyResult)
    {
        if (queryIntermediateResult is not null)
        {
            queryIntermediateResult.Namespace = queryNamespace;
            queryIntermediateResult.ModelIdPropertyResult = modelIdPropertyResult;
            queryIntermediateResults.Add(queryIntermediateResult);
        }
    }

    #endregion
}