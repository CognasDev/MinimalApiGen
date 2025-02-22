using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MinimalApiGen.Framework.Services;

/// <summary>
/// 
/// </summary>
public sealed class HttpClientService : IHttpClientService
{
    #region Field Declarations

    private static readonly JsonSerializerOptions _caseInsensitiveSerializer = new() { PropertyNameCaseInsensitive = true };
    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="HttpClientService"/>
    /// </summary>
    /// <param name="httpClientFactory"></param>
    public HttpClientService(IHttpClientFactory httpClientFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    public async Task<TResponse?> GetAsync<TResponse>(string requestUri)
    {
        HttpClient httpClient = CreateHttpClient();
        using HttpResponseMessage response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return default;
        }
        response.EnsureSuccessStatusCode();
        using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, _caseInsensitiveSerializer).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async IAsyncEnumerable<TResponse> GetAsyncEnumerable<TResponse>(string requestUri, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        HttpClient httpClient = CreateHttpClient();
        using HttpResponseMessage response = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        using Stream responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await foreach (TResponse? responseItem in JsonSerializer.DeserializeAsyncEnumerable<TResponse>(responseStream, _caseInsensitiveSerializer, cancellationToken).ConfigureAwait(false))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return responseItem ?? throw new NullReferenceException(nameof(responseItem));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<LocationResponse<TResponse>> PostAsync<TRequest, TResponse>(string requestUri, TRequest request)
        where TRequest : notnull
        where TResponse : class
    {
        HttpClient httpClient = CreateHttpClient();
        using HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync(requestUri, request).ConfigureAwait(false);
        responseMessage.EnsureSuccessStatusCode();
        using Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
        TResponse? response = await JsonSerializer.DeserializeAsync<TResponse>(responseStream, _caseInsensitiveSerializer).ConfigureAwait(false);
        LocationResponse<TResponse> locationResponse = new(response, responseMessage.Headers.Location);
        return locationResponse;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string requestUri, TRequest request)
    {
        HttpClient httpClient = CreateHttpClient();
        using HttpResponseMessage response = await httpClient.PutAsJsonAsync(requestUri, request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        using Stream responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, _caseInsensitiveSerializer).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    public async Task DeleteAsync(string requestUri)
    {
        HttpClient httpClient = CreateHttpClient();
        using HttpResponseMessage response = await httpClient.DeleteAsync(requestUri).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private HttpClient CreateHttpClient()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient();
        return httpClient;
    }

    #endregion
}