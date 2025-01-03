using MinimalApiGen.Generators.Query.Invocation;
using MinimalApiGen.Generators.Query.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Query.Fluent;

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
    /// <returns></returns>
    public static QueryIntermediateResult InitialiseQueryIntermediateResult(this QueryInvocationDetails queryInvocationDetails)
    {
        QueryIntermediateResult result = new()
        {
            ModelFullyQualifiedName = queryInvocationDetails.ModelFullyQualifiedName,
            ModelPluralName = queryInvocationDetails.ModelPluralName,
            ModelName = queryInvocationDetails.ModelName
        };
        result.ModelProperties.AddRange(queryInvocationDetails.PropertyNames);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryIntermediateResults"></param>
    /// <param name="queryIntermediateResult"></param>
    /// <param name="masterNamespace"></param>
    /// <param name="classNamespace"></param>
    public static void TryFinaliseAndCollectIntermediateResult(this List<QueryIntermediateResult> queryIntermediateResults,
                                                               QueryIntermediateResult? queryIntermediateResult,
                                                               string masterNamespace,
                                                               string classNamespace)
    {
        if (queryIntermediateResult is not null)
        {
            queryIntermediateResult.ClassNamespace = string.IsNullOrWhiteSpace(classNamespace) ? masterNamespace : classNamespace;
            queryIntermediateResults.Add(queryIntermediateResult);
        }
    }

    #endregion
}