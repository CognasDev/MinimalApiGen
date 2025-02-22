namespace MinimalApiGen.Framework.Services;

/// <summary>
/// 
/// </summary>
public interface IHttpClientService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    Task<TResponse?> GetAsync<TResponse>(string requestUri);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    IAsyncEnumerable<TResponse> GetAsyncEnumerable<TResponse>(string requestUri, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<LocationResponse<TResponse>> PostAsync<TRequest, TResponse>(string requestUri, TRequest request)
        where TRequest : notnull
        where TResponse : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="requestUri"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<TResponse?> PutAsync<TRequest, TResponse>(string requestUri, TRequest request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    Task DeleteAsync(string requestUri);

    #endregion
}