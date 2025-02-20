namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class CachedForBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public static string Build(string? timeSpan)
    {
        if (string.IsNullOrWhiteSpace(timeSpan))
        {
            return string.Empty;
        }
        return
    @$"
        .CacheOutput(builder => builder.Expire({timeSpan}))";
    }

    #endregion
}