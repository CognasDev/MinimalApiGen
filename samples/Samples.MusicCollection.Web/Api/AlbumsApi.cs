using Microsoft.Extensions.Options;
using Samples.MusicCollection.Web.Config;
using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
/// <param name="httpClientFactory"></param>
/// <param name="apiDetailsMonitor"></param>
public sealed class AlbumsApi(IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    : Api<Album>(httpClientFactory, apiDetailsMonitor), IAlbumsApi
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public IAsyncEnumerable<Album?> GetAsync(int artistId, CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = HttpClientFactory.CreateClient();
        string requestUri = $"{RequestUri}?{nameof(artistId)}={artistId}";
        return httpClient.GetFromJsonAsAsyncEnumerable<Album?>(requestUri, cancellationToken);
    }

    #endregion
}