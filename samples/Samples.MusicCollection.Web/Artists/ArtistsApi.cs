using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.Artists;

/// <summary>
/// 
/// </summary>
/// <param name="httpClientFactory"></param>
public sealed partial class ArtistsApi(IHttpClientFactory httpClientFactory) : IArtistsApi
{
    #region Field Declarations

    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Artist>> GetArtistsAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        IAsyncEnumerable<Artist?> response = httpClient.GetFromJsonAsAsyncEnumerable<Artist?>("https://localhost:7104/api/v1/artists");
        ConcurrentBag<Artist> artists = [];

        await foreach (Artist? artist in response.ConfigureAwait(false))
        {
            if (artist is not null)
            {
                artists.Add(artist);
            }
        }
        return artists;
    }

    #endregion
}