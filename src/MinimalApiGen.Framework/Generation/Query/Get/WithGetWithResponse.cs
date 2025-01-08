using MinimalApiGen.Framework.Generation.Query.Common;
using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithResponse : IWithGetWithResponse
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public IQueryWithCache CachedFor(TimeSpan timeSpan) => new QueryWithCache();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IQueryWithMappingService WithMappingService() => new QueryWithMappingService();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetPaginationService WithPagination() => new WithGetPaginationService();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public IQueryOperations WithVersion(int version) => new QueryOperations();

    #endregion
}