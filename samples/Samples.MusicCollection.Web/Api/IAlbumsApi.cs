using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
public interface IAlbumsApi : IApi<Album>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<Album?> GetAsync(int artistId, CancellationToken cancellationToken = default);

    #endregion
}