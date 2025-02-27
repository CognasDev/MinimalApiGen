using Radzen;
using Samples.MusicCollection.Web.Api;
using Samples.MusicCollection.Web.Models;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed class AllMusicLogic : IAllMusicLogic
{
    #region Field Declarations

    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly IApi<Artist> _artistsApi;
    private readonly IAlbumsApi _albumsApi;
    private readonly IApi<Genre> _genresApi;
    private readonly IApi<Key> _keysApi;
    private readonly IApi<Label> _labelsApi;
    private readonly ITracksApi _tracksApi;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistDetail> Artists { get; private  set; } = [];

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
                         IAlbumsApi albumsApi,
                         IApi<Genre> genresApi,
                         IApi<Key> keysApi,
                         IApi<Label> labelsApi,
                         ITracksApi tracksApi)
    {
        ArgumentNullException.ThrowIfNull(artistsApi, nameof(artistsApi));
        ArgumentNullException.ThrowIfNull(albumsApi, nameof(albumsApi));
        ArgumentNullException.ThrowIfNull(genresApi, nameof(genresApi));
        ArgumentNullException.ThrowIfNull(keysApi, nameof(keysApi));
        ArgumentNullException.ThrowIfNull(labelsApi, nameof(labelsApi));
        ArgumentNullException.ThrowIfNull(tracksApi, nameof(tracksApi));

        _artistsApi = artistsApi;
        _albumsApi = albumsApi;
        _genresApi = genresApi;
        _keysApi = keysApi;
        _labelsApi = labelsApi;
        _tracksApi = tracksApi;
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
            List<ArtistDetail> artists = [];
            await foreach (Artist? artist in _artistsApi.GetAsync(cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (artist is not null)
                {
                    ArtistDetail artistDetail = new()
                    {
                        ArtistId = artist.ArtistId,
                        Name = artist.Name,
                    };
                    artists.Add(artistDetail);
                }
            }
            Artists = artists;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async IAsyncEnumerable<AlbumDetail> GetAlbumsAsync(int artistId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (Album? album in _albumsApi.GetAsync(artistId, cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (album is not null)
            {
                AlbumDetail albumDetail = new()
                {
                    AlbumId = album.AlbumId,
                    ArtistId = album.ArtistId,
                    GenreId = album.GenreId,
                    LabelId = album.LabelId,
                    Name = album.Name,
                    ReleaseDate = album.ReleaseDate,
                };
                yield return albumDetail;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async IAsyncEnumerable<TrackDetail> GetTracksAsync(int albumId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (Track? track in _tracksApi.GetAsync(albumId, cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (track is not null)
            {
                TrackDetail trackDetail = new()
                {
                    TrackId = track.TrackId,
                    Name = track.Name,
                    Bpm = track.Bpm,
                    GenreId = track.GenreId,
                    KeyId = track.KeyId,
                    TrackNumber = track.TrackNumber,
                };
                yield return trackDetail;
            }
        }
    }

    #endregion
}