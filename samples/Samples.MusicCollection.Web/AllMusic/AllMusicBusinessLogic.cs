using MinimalApiGen.Shared.Collections;
using Samples.MusicCollection.Web.Api;
using Samples.MusicCollection.Web.Models;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Runtime.CompilerServices;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed class AllMusicBusinessLogic : IAllMusicBusinessLogic
{
    #region Field Declarations

    private static readonly SemaphoreSlim _semaphore = new(1, 1);
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
    public IEnumerable<ArtistDetail> Artists { get; private set; } = [];

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Genre> Genres { get; private set; } = [];

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Key> Keys { get; private set; } = [];

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Label> Labels { get; private set; } = [];

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
    public AllMusicBusinessLogic(IApi<Artist> artistsApi,
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
        ConcurrentBag<ArtistDetail> artists = [];
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task GetGenresAsync(CancellationToken cancellationToken = default)
    {
        if (Genres.Any())
        {
            return;
        }
        ConcurrentBag<Genre> genres = [];
        await foreach (Genre? genre in _genresApi.GetAsync(cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (genre is not null)
            {
                genres.Add(genre);
            }
        }
        Genres = genres;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task GetKeysAsync(CancellationToken cancellationToken = default)
    {
        await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (Keys.Any())
            {
                return;
            }
            ConcurrentBag<Key> keys = [];
            await foreach (Key? key in _keysApi.GetAsync(cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (key is not null)
                {
                    keys.Add(key);
                }
            }
            Keys = keys.ToFrozenSet();
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
    public async Task GetLabelsAsync(CancellationToken cancellationToken = default)
    {
        if (Labels.Any())
        {
            return;
        }
        ConcurrentBag<Label> labels = [];
        await foreach (Label? label in _labelsApi.GetAsync(cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (label is not null)
            {
                labels.Add(label);
            }
        }
        Labels = labels;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="genreId"></param>
    /// <returns></returns>
    public string GenreName(int? genreId) => genreId.HasValue ? Genres.FastSingle(genre => genre.GenreId == genreId.Value).Name : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyId"></param>
    /// <returns></returns>
    public string KeyNameAndCamelot(int? keyId)
    {
        if (!keyId.HasValue)
        {
            return string.Empty;
        }
        Key key = Keys.FastSingle(key => key.KeyId == keyId.Value);
        string nameAndCamelot = $"{key.CamelotCode} - {key.Name}";
        return nameAndCamelot;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="labelId"></param>
    /// <returns></returns>
    public string LabelName(int? labelId) => labelId.HasValue ? Labels.FastSingle(label => label.LabelId == labelId.Value).Name : string.Empty;

    #endregion
}