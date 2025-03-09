using Microsoft.Extensions.Options;
using Samples.MusicCollection.Web.Config;
using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
/// <param name="httpClientFactory"></param>
/// <param name="apiDetailsMonitor"></param>
public sealed class TracksApi(IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    : Api<Track>(httpClientFactory, apiDetailsMonitor), ITracksApi
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public IAsyncEnumerable<Track?> GetAsync(int albumId, CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = HttpClientFactory.CreateClient();
        string requestUri = $"{RequestUri}?{nameof(albumId)}={albumId}";
        return httpClient.GetFromJsonAsAsyncEnumerable<Track?>(requestUri, cancellationToken);
    }

    #endregion
}