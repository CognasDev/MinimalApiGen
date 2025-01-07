using MinimalApiGen.Framework.Generation.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithCache : IWithGetWithCache
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGet WithGet() => new WithGet();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetById WithGetById() => new WithGetById();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public IWithGetWithVersion WithVersion(int version) => new WithGetWithVersion();

    #endregion
}