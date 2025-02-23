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
    public async Task<IEnumerable<ArtistResponse>> GetArtistsAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        IAsyncEnumerable<ArtistResponse?> response = httpClient.GetFromJsonAsAsyncEnumerable<ArtistResponse?>("https://localhost:7104/api/v1/artists");
        ConcurrentBag<ArtistResponse> artists = [];

        await foreach (ArtistResponse? artist in response.ConfigureAwait(false))
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