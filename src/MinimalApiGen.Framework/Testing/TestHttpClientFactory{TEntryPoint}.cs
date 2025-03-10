using Microsoft.AspNetCore.Mvc.Testing;

namespace MinimalApiGen.Framework.Testing;

/// <summary>
/// 
/// </summary>
/// <param name="webApplicationFactory"></param>
public sealed class TestHttpClientFactory<TEntryPoint>(WebApplicationFactory<TEntryPoint> webApplicationFactory) : IHttpClientFactory
    where TEntryPoint : class
{
    #region Field Delarations

    private readonly WebApplicationFactory<TEntryPoint> _webApplicationFactory = webApplicationFactory;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public HttpClient CreateClient(string name) => _webApplicationFactory.CreateClient();

    #endregion
}