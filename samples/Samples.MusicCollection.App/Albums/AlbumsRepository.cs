using Cognas.MauiTools.Shared.Services;
using Microsoft.Extensions.Options;
using Samples.MusicCollection.App.Configuration;
using System.Collections.ObjectModel;

namespace Samples.MusicCollection.App.Albums;

/// <summary>
/// 
/// </summary>
public sealed class AlbumsRepository : IAlbumsRepository
{
    #region Field Declarations

    private readonly IHttpClientService _httpClientService;
    private readonly BaseAddresses _baseAddresses;
    private readonly MicroserviceUris _microserviceUris;
    private readonly ObservableCollection<Album> _albums = [];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Album> Albums => _albums;

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="AlbumsRepository"/>
    /// </summary>
    /// <param name="httpClientService"></param>
    /// <param name="baseAddresses"></param>
    /// <param name="microserviceUris"></param>
    public AlbumsRepository(IHttpClientService httpClientService, IOptions<BaseAddresses> baseAddresses, IOptions<MicroserviceUris> microserviceUris)
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
        string requestUri = $"{_baseAddresses.GetBaseAddress()}{_microserviceUris.Albums}";
        IAsyncEnumerable<Album> albums = _httpClientService.GetAsyncEnumerable<Album>(requestUri, CancellationToken.None);
        _albums.Clear();
        await foreach (Album Album in albums.ConfigureAwait(false))
        {
            _albums.Add(Album);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Album"></param>
    /// <returns></returns>
    public async Task CreateAsync(Album Album)
    {
        LocationResponse<Album> locationResponse = await _httpClientService.PostAsync<Album, Album>(_microserviceUris.Albums, Album).ConfigureAwait(false);
        if (locationResponse.Success)
        {
            _albums.Add(locationResponse.Response!);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Album"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateAsync(Album Album)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Album"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteAsync(Album Album)
    {
        throw new NotImplementedException();
    }

    #endregion
}