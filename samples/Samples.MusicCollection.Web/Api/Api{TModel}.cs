using Microsoft.Extensions.Options;
using MinimalApiGen.Framework.Pluralize;
using Samples.MusicCollection.Web.Config;

namespace Samples.MusicCollection.Web.Api;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public class Api<TModel> : IApi<TModel>, IDisposable
{
    #region Field Declarations

    private ApiDetails _apiDetails;
    private readonly IDisposable? _configChangeListener;
    private bool _disposed;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected IHttpClientFactory HttpClientFactory { get; }

    /// <summary>
    /// 
    /// </summary>
    protected string PluralModelName { get; }

    /// <summary>
    /// 
    /// </summary>
    protected string RequestUri => $"{_apiDetails.Url}/{PluralModelName}";

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpClientFactory"></param>
    /// <param name="pluralizer"></param>
    /// <param name="apiDetailsMonitor"></param>
    public Api(IHttpClientFactory httpClientFactory, IPluralizer pluralizer, IOptionsMonitor<ApiDetails> apiDetailsMonitor)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        ArgumentNullException.ThrowIfNull(pluralizer, nameof(pluralizer));
        ArgumentNullException.ThrowIfNull(apiDetailsMonitor, nameof(apiDetailsMonitor));

        _configChangeListener = apiDetailsMonitor.OnChange(apiDetails => _apiDetails = apiDetails);

        HttpClientFactory = httpClientFactory;
        PluralModelName = pluralizer.Pluralize(typeof(TModel).Name).ToLowerInvariant();
        _apiDetails = apiDetailsMonitor.CurrentValue;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public IAsyncEnumerable<TModel?> GetAsync(CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = HttpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsAsyncEnumerable<TModel?>(RequestUri, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<TModel?> InsertAsync(TModel model, CancellationToken cancellationToken = default)
    {
        HttpClient httpClient = HttpClientFactory.CreateClient();
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