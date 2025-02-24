using Microsoft.Extensions.Options;
using Samples.MusicCollection.Web.Config;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
public sealed partial class AlbumRepository : IAlbumRepository, IDisposable
{
    #region Field Declarations

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConcurrentBag<Album> _albums = [];
    private ApiDetails _apiDetails;

    private readonly IDisposable? _configChangeListener;
    private bool _disposed;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="apiDetailsMonitor"></param>
    public AlbumRepository(IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory,nameof(httpClientFactory));
        ArgumentNullException.ThrowIfNull(apiDetailsMonitor, nameof(apiDetailsMonitor));

        _configChangeListener = apiDetailsMonitor.OnChange(apiDetails => _apiDetails = apiDetails);

        _httpClientFactory = httpClientFactory;
        _apiDetails = apiDetailsMonitor.CurrentValue;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> GetAlbumsAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        IAsyncEnumerable<Album?> response = httpClient.GetFromJsonAsAsyncEnumerable<Album?>($"{_apiDetails.Url}/albums");
        _albums.Clear();

        await foreach (Album? album in response.ConfigureAwait(false))
        {
            if (album is not null)
            {
                _albums.Add(album);
            }
        }
        return _albums;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    public async Task<Album?> InsertAlbumAsync(Album album)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync($"{_apiDetails.Url}/albums", album).ConfigureAwait(false);
        responseMessage.EnsureSuccessStatusCode();
        Album? insertedAlbum = await responseMessage.Content.ReadFromJsonAsync<Album>().ConfigureAwait(false);
        return insertedAlbum;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _configChangeListener?.Dispose();
        }
        _disposed = true;
    }

    #endregion
}