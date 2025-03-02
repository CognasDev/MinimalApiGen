﻿using Microsoft.Extensions.Options;
using MinimalApiGen.Framework.Pluralize;
using Samples.MusicCollection.Web.Config;
using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
public sealed class TracksApi(IHttpClientFactory httpClientFactory, IPluralizer pluralizer, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    : Api<Track>(httpClientFactory, pluralizer, apiDetailsMonitor), ITracksApi
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