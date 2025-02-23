using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
/// <param name="httpClientFactory"></param>
public sealed partial class AlbumsApi(IHttpClientFactory httpClientFactory) : IAlbumsApi
{
    #region Field Declarations

    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> GetAlbumsAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        IAsyncEnumerable<Album?> response = httpClient.GetFromJsonAsAsyncEnumerable<Album?>("https://localhost:7104/api/v1/albums");
        ConcurrentBag<Album> albums = [];

        await foreach (Album? album in response.ConfigureAwait(false))
        {
            if (album is not null)
            {
                albums.Add(album);
            }
        }
        return albums;
    }

    #endregion
}