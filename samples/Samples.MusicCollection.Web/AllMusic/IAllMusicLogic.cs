using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public interface IAllMusicLogic
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    IApi<Artist> ArtistsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IApi<Album> AlbumsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IApi<Genre> GenresApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IApi<Key> KeysApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IApi<Label> LabelsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IApi<Track> TracksApi { get; }

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<ArtistDetail> Artists { get; }

    #endregion

    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetArtistsAsync(CancellationToken cancellationToken = default);

    #endregion
}