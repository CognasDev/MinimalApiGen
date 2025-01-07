namespace MinimalApiGen.Framework.Generation.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithResponse
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WithGetWithMappingService WithMappingService() => new();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WithGetPaginationService WithPaginationService() => new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public WithGetWithVersion WithVersion(int version) => new();

    #endregion
}