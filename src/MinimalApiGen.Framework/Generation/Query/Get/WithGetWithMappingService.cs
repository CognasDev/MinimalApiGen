using MinimalApiGen.Generators.Abstractions.Query.Get;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithMappingService : IWithGetWithMappingService
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
    /// <param name="version"></param>
    /// <returns></returns>
    public IWithGetWithVersion WithVersion(int version) => new WithGetWithVersion();

    #endregion
}