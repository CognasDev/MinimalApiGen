using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal sealed record QueryIntermediateResult : IntermediateResultBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string? CachedFor { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<QueryParameterResult> QueryParameterResults { get; set; } = [];

    /// <summary>
    /// 
    /// </summary>
    public bool WithPagination { get; set; }

    #endregion
}