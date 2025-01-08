namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
public sealed class CachedForBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Build(string? timeSpan)
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