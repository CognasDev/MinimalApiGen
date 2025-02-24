using Microsoft.Extensions.Options;
using Samples.MusicCollection.Web.Config;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
public sealed partial class AlbumRepository : IAlbumRepository
{
    #region Field Declarations

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiDetails _apiDetails;
    private readonly ConcurrentBag<Album> _albums = [];

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="apiDetails"></param>
    public AlbumRepository(IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiDetails> apiDetails)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory,nameof(httpClientFactory));
        ArgumentNullException.ThrowIfNull(apiDetails, nameof(apiDetails));
        _httpClientFactory = httpClientFactory;
        _apiDetails = apiDetails.CurrentValue;
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
    public async Task<IEnumerable<Album>> InsertAlbumAsync(Album album)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync($"{_apiDetails.Url}/albums", album).ConfigureAwait(false);
        responseMessage.EnsureSuccessStatusCode();
        using Stream receiveStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
        Album? insertedAlbum = await JsonSerializer.DeserializeAsync<Album>(receiveStream).ConfigureAwait(false);
        if (insertedAlbum is not null)
        {
            _albums.Add(insertedAlbum);
        }
        return _albums;
    }

    #endregion
}