namespace Samples.MusicCollection.Web;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IRepository<TModel>
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<TModel> Models { get; }

    #endregion

    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<TModel>> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TModel?> InsertAsync(TModel model, CancellationToken cancellationToken = default);

    #endregion
}