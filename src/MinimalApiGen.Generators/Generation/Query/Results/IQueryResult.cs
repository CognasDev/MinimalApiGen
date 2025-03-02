﻿using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal interface IQueryResult : IResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    bool WithPagination { get; }

    /// <summary>
    /// 
    /// </summary>
    bool WithResponseMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    string? CachedFor { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<QueryParameterResult> QueryParameterResults { get; }

    #endregion
}