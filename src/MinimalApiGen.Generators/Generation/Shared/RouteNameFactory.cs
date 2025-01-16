namespace MinimalApiGen.Generators.Generation.Shared;

/// <summary>
/// 
/// </summary>
internal static class RouteNameFactory
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelPluralName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    public static string Get(string modelPluralName, int apiVersion) => $"{modelPluralName}-Get-V{apiVersion}";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelPluralName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    public static string GetById(string modelPluralName, int apiVersion) => $"{modelPluralName}-GetById-V{apiVersion}";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelPluralName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    public static string Post(string modelPluralName, int apiVersion) => $"{modelPluralName}-Post-V{apiVersion}";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelPluralName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    public static string Put(string modelPluralName, int apiVersion) => $"{modelPluralName}-Put-V{apiVersion}";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelPluralName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    public static string Delete(string modelPluralName, int apiVersion) => $"{modelPluralName}-Delete-V{apiVersion}";

    #endregion
}