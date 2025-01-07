namespace MinimalApiGen.Framework.Generation.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetPaginationService
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
    /// <param name="version"></param>
    /// <returns></returns>
    public WithGetWithVersion WithVersion(int version) => new();

    #endregion
}