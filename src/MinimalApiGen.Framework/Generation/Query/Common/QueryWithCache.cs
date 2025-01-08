using MinimalApiGen.Framework.Generation.Query.Get;
using MinimalApiGen.Framework.Generation.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.Common;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Framework.Generation.Query.Common;

/// <summary>
/// 
/// </summary>
public sealed class QueryWithCache : IQueryWithCache
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetOperation WithGet() => new WithGetOperation();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetByIdOperation WithGetById() => new WithGetByIdOperation();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public IQueryOperations WithVersion(int version) => new QueryOperations();

    #endregion
}