namespace Samples.MusicCollection.Web.Sorting;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface ISortingService<TModel>
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    bool IsSortedAscending { get; }

    /// <summary>
    /// 
    /// </summary>
    string? CurrentSortKey { get; }

    #endregion

    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sortKey"></param>
    /// <returns></returns>
    IEnumerable<TModel> Sort(IEnumerable<TModel> source, string sortKey);

    #endregion
}