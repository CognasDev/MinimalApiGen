namespace Samples.MusicCollection.Web;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IApi<TModel>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<TModel?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TModel?> InsertAsync(TModel model, CancellationToken cancellationToken = default);

    #endregion
}