using MinimalApiGen.Generators.Generation.Query.Invocation;
using MinimalApiGen.Generators.Generation.Query.Results;
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
    /// <param name="queryType"></param>
    /// <returns></returns>
    public static QueryIntermediateResult InitialiseQueryIntermediateResult(this QueryInvocationDetails queryInvocationDetails, QueryType queryType)
    {
        QueryIntermediateResult result = new()
        {
            ModelFullyQualifiedName = queryInvocationDetails.ModelFullyQualifiedName,
            ModelPluralName = queryInvocationDetails.ModelPluralName,
            ModelName = queryInvocationDetails.ModelName,
            QueryType = queryType
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
    public static void TryFinaliseAndCollectIntermediateResult(this List<QueryIntermediateResult> queryIntermediateResults,
                                                               QueryIntermediateResult? queryIntermediateResult,
                                                               string queryNamespace)
    {
        if (queryIntermediateResult is not null)
        {
            queryIntermediateResult.QueryNamespace = queryNamespace;
            queryIntermediateResults.Add(queryIntermediateResult);
        }
    }

    #endregion
}