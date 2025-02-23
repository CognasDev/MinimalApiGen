using System.Reflection;

namespace Samples.MusicCollection.Web.Sorting;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class SortingService<TModel> : ISortingService<TModel>
{
    #region Field Declarations

    private readonly Type _modelType;
    private readonly Dictionary<string, PropertyInfo?> _propertyCache = [];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public bool IsSortedAscending { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CurrentSortKey { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    public SortingService() => _modelType = typeof(TModel);

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sortKey"></param>
    /// <returns></returns>
    public IEnumerable<TModel> Sort(IEnumerable<TModel> source, string sortKey)
    {
        PropertyInfo? propertyInfo = GetOrCacheProperty(sortKey);
        IEnumerable<TModel> sortedModels;

        if (sortKey != CurrentSortKey)
        {
            sortedModels = source.OrderBy(model => propertyInfo!.GetValue(model, null));
            CurrentSortKey = sortKey;
            IsSortedAscending = true;
        }
        else
        {
            IsSortedAscending = !IsSortedAscending;
            sortedModels = IsSortedAscending ?
                                source.OrderBy(model => propertyInfo!.GetValue(model, null)) :
                                source.OrderByDescending(model => propertyInfo!.GetValue(model, null));
        }
        return sortedModels;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sortKey"></param>
    /// <returns></returns>
    private PropertyInfo? GetOrCacheProperty(string sortKey)
    {
        if (!_propertyCache.TryGetValue(sortKey, out PropertyInfo? propertyInfo))
        {
            propertyInfo = _modelType.GetProperty(sortKey);
            _propertyCache[sortKey] = propertyInfo;
        }
        return propertyInfo;
    }

    #endregion
}