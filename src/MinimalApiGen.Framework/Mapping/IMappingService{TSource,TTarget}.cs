namespace MinimalApiGen.Framework.Mapping;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TTarget"></typeparam>
public interface IMappingService<TSource, TTarget>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    TTarget Map(TSource source);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sourceCollection"></param>
    /// <returns></returns>
    IEnumerable<TTarget> Map(IEnumerable<TSource> sourceCollection);

    #endregion
}