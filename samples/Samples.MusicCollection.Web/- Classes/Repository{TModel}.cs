using Microsoft.Extensions.Options;
using MinimalApiGen.Framework.Pluralize;
using Samples.MusicCollection.Web.Config;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class Repository<TModel> : IRepository<TModel>, IDisposable
{
    #region Field Declarations

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConcurrentBag<TModel> _models = [];
    private ApiDetails _apiDetails;

    private readonly IDisposable? _configChangeListener;
    private bool _disposed;
    private readonly string _pluralModelName;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    private string RequestUri => $"{_apiDetails.Url}/{_pluralModelName}";

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<TModel> Models => _models;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="pluralizer"></param>
    /// <param name="apiDetailsMonitor"></param>
    public Repository(IHttpClientFactory httpClientFactory, IPluralizer pluralizer, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory,nameof(httpClientFactory));
        ArgumentNullException.ThrowIfNull(pluralizer, nameof(pluralizer));
        ArgumentNullException.ThrowIfNull(apiDetailsMonitor, nameof(apiDetailsMonitor));

        _configChangeListener = apiDetailsMonitor.OnChange(apiDetails => _apiDetails = apiDetails);

        _httpClientFactory = httpClientFactory;
        _pluralModelName = pluralizer.Pluralize(typeof(TModel).Name).ToLowerInvariant();
        _apiDetails = apiDetailsMonitor.CurrentValue;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TModel>> GetAsync(CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        IAsyncEnumerable<TModel?> response = httpClient.GetFromJsonAsAsyncEnumerable<TModel?>(RequestUri, cancellationToken);
        _models.Clear();

        await foreach (TModel? model in response.ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (model is not null)
            {
                _models.Add(model);
            }
        }
        return _models;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TModel?> InsertAsync(TModel model, CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        using HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync(RequestUri, model, cancellationToken).ConfigureAwait(false);
        responseMessage.EnsureSuccessStatusCode();
        TModel? insertedModel = await responseMessage.Content.ReadFromJsonAsync<TModel>(cancellationToken).ConfigureAwait(false);
        return insertedModel;
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