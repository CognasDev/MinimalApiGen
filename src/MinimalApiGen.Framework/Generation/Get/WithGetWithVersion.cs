namespace MinimalApiGen.Framework.Generation.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithVersion
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public WithGetWithCache CachedFor(TimeSpan timeSpan) => new();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WithGet WithGet() => new();

    #endregion
}
