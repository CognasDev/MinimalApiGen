using MinimalApiGen.Framework.Generation.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithVersion : IWithGetWithVersion
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public IWithGetWithCache CachedFor(TimeSpan timeSpan) => new WithGetWithCache();

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

    #endregion
}