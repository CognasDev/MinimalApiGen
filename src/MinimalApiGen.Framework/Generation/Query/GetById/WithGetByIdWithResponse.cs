using MinimalApiGen.Framework.Generation.Query.Shared;
using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Framework.Generation.Query.GetById;

/// <summary>
/// 
/// </summary>
public sealed class WithGetByIdWithResponse : IWithGetByIdWithResponse
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
    /// <param name="version"></param>
    /// <returns></returns>
    public IQueryOperations WithVersion(int version) => new QueryOperations();

    #endregion
}