using Radzen;
using Samples.MusicCollection.Web.Api;
using Samples.MusicCollection.Web.Models;
using System.Runtime.CompilerServices;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public interface IAllMusicBusinessLogic
{
    #region Property Declarations
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<ArtistDetail> Artists { get; }

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Genre> Genres { get; }

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Key> Keys { get; }

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Label> Labels { get; }

    #endregion

    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetArtistsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<AlbumDetail> GetAlbumsAsync(int artistId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetGenresAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetKeysAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetLabelsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<TrackDetail> GetTracksAsync(int albumId, CancellationToken cancellationToken = default);

    #endregion
}