using Samples.MusicCollection.Web.Models;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed class AllMusicLogic : IAllMusicLogic
{
    #region Field Declarations

    private readonly ConcurrentBag<ArtistDetail> _artists = [];
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IApi<Artist> ArtistsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IApi<Album> AlbumsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IApi<Genre> GenresApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IApi<Key> KeysApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IApi<Label> LabelsApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IApi<Track> TracksApi { get; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistDetail> Artists => _artists;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistsApi"></param>
    /// <param name="albumsApi"></param>
    /// <param name="genresApi"></param>
    /// <param name="keysApi"></param>
    /// <param name="labelsApi"></param>
    /// <param name="tracksApi"></param>
    public AllMusicLogic(IApi<Artist> artistsApi,
                         IApi<Album> albumsApi,
                         IApi<Genre> genresApi,
                         IApi<Key> keysApi,
                         IApi<Label> labelsApi,
                         IApi<Track> tracksApi)
    {
        ArgumentNullException.ThrowIfNull(artistsApi, nameof(artistsApi));
        ArgumentNullException.ThrowIfNull(albumsApi, nameof(albumsApi));
        ArgumentNullException.ThrowIfNull(genresApi, nameof(genresApi));
        ArgumentNullException.ThrowIfNull(keysApi, nameof(keysApi));
        ArgumentNullException.ThrowIfNull(labelsApi, nameof(labelsApi));
        ArgumentNullException.ThrowIfNull(tracksApi, nameof(tracksApi));

        ArtistsApi = artistsApi;
        AlbumsApi = albumsApi;
        GenresApi = genresApi;
        KeysApi = keysApi;
        LabelsApi = labelsApi;
        TracksApi = tracksApi;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task GetArtistsAsync(CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _artists.Clear();
            await foreach (Artist? artist in ArtistsApi.GetAsync(cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (artist is not null)
                {
                    ArtistDetail artistDetail = new()
                    {
                        ArtistId = artist.ArtistId,
                        Name = artist.Name,
                    };
                    _artists.Add(artistDetail);
                }
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task GetAlbumsAsync(int artistId, CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _artists.Clear();
            await foreach (Artist? artist in ArtistsApi.GetAsync(cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (artist is not null)
                {
                    ArtistDetail artistDetail = new()
                    {
                        ArtistId = artist.ArtistId,
                        Name = artist.Name,
                    };
                    _artists.Add(artistDetail);
                }
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    #endregion
}