using MinimalApiGen.Framework.Collections;

namespace MinimalApiGen.Framework.Mapping;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TTarget"></typeparam>
public abstract class MappingServiceBase<TSource, TTarget> : IMappingService<TSource, TTarget>
{
    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    protected MappingServiceBase()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public abstract TTarget Map(TSource source);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sourceCollection"></param>
    /// <returns></returns>
    public IEnumerable<TTarget> Map(IEnumerable<TSource> sourceCollection)
    {
        List<TTarget> targets = [];
        sourceCollection.FastForEach(source =>
        {
            TTarget target = Map(source);
            targets.Add(target);
        });
        return targets;
    }

    #endregion
}