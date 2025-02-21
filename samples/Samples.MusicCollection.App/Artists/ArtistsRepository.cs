using Cognas.MauiTools.Shared.Services;
using Microsoft.Extensions.Options;
using Samples.MusicCollection.App.Configuration;
using System.Collections.ObjectModel;

namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public sealed class ArtistsRepository : IArtistsRepository
{
    #region Field Declarations

    private readonly IHttpClientService _httpClientService;
    private readonly BaseAddresses _baseAddresses;
    private readonly MicroserviceUris _microserviceUris;
    private readonly ObservableCollection<Artist> _artists = [];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Artist> Artists => _artists;

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistsRepository"/>
    /// </summary>
    /// <param name="httpClientService"></param>
    /// <param name="baseAddresses"></param>
    /// <param name="microserviceUris"></param>
    public ArtistsRepository(IHttpClientService httpClientService, IOptions<BaseAddresses> baseAddresses, IOptions<MicroserviceUris> microserviceUris)
    {
        ArgumentNullException.ThrowIfNull(httpClientService, nameof(httpClientService));
        ArgumentNullException.ThrowIfNull(baseAddresses, nameof(baseAddresses));
        ArgumentNullException.ThrowIfNull(microserviceUris, nameof(microserviceUris));

        _baseAddresses = baseAddresses.Value;
        _httpClientService = httpClientService;
        _microserviceUris = microserviceUris.Value;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task InitiateAsync()
    {
        string requestUri = $"{_baseAddresses.GetBaseAddress()}{_microserviceUris.Artists}";
        IAsyncEnumerable<Artist> artists = _httpClientService.GetAsyncEnumerable<Artist>(requestUri, CancellationToken.None);
        _artists.Clear();
        await foreach (Artist artist in artists.ConfigureAwait(false))
        {
            _artists.Add(artist);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    public async Task CreateAsync(Artist artist)
    {
        LocationResponse<Artist> locationResponse = await _httpClientService.PostAsync<Artist, Artist>(_microserviceUris.Artists, artist).ConfigureAwait(false);
        if (locationResponse.Success)
        {
            _artists.Add(locationResponse.Response!);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateAsync(Artist artist)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteAsync(Artist artist)
    {
        throw new NotImplementedException();
    }

    #endregion
}