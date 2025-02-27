using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
public interface ITracksApi : IApi<Track>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<Track?> GetAsync(int albumId, CancellationToken cancellationToken = default);

    #endregion
}